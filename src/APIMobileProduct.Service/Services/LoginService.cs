using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos;
using APIMobileProduct.Domain.Dtos.Permit;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;
using APIMobileProduct.Domain.Interfaces.Services.Company;
using APIMobileProduct.Domain.Repository;
using APIMobileProduct.Domain.Security;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APIMobileProduct.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        private IRepository<CompanyEntity> _repositoryCompany;

        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private readonly IMapper _mapper;
        private IConfiguration _configuration { get; }


        public LoginService(IUserRepository repository,
                            IRepository<CompanyEntity> repositoryCompany,
                            SigningConfigurations signingConfigurations,
                            TokenConfigurations tokenConfigurations,
                            IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _repositoryCompany = repositoryCompany;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<object> FindByLogin(LoginDto login)
        {
            var baseUser = new UserEntity();
            if (login != null && !string.IsNullOrWhiteSpace(login.Email))
            {
                baseUser = await _repository.FindByLogin(login.Email, login.Senha);
                var company = await _repositoryCompany.SelectAsync(baseUser.CompanyId);
                HashSet<PermitDto> permits = new HashSet<PermitDto>();

                foreach (var profile in baseUser.Group.Profiles)
                {
                    foreach (var permit in profile.Permits)
                    {
                        var permitDto = _mapper.Map<PermitDto>(permit);
                        permits.Add(permitDto);

                    }
                }

                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                IdentityOptions _options = new IdentityOptions();
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(baseUser.Email),
                    new[]{
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // jti o id do token
                        new Claim(JwtRegisteredClaimNames.UniqueName, login.Email),
                        new Claim(JwtRegisteredClaimNames.Sid ,baseUser.CompanyId.ToString()),
                    }
                );
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);
                return SuccessObject(createDate, expirationDate, token, baseUser, company, permits);
            }

            return null;
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });


            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user, CompanyEntity company, IEnumerable<PermitDto> permits)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userlogin = user.Email,
                name = user.Nome,
                message = "Usuário Logado com Sucesso.",
                companyId = user.CompanyId,
                groupId = user.GroupId,
                group_ctc = company.Nome.ToUpper().Contains("CTC"),
                permits = permits
            };
        }
    }
}
