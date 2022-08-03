using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.User;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;
using APIMobileProduct.Domain.Interfaces.Services.User;
using APIMobileProduct.Domain.Models;
using APIMobileProduct.Domain.Repository;
using AutoMapper;

namespace APIMobileProduct.Service.Services
{
    //Regra de negocio
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IRepository<CompanyEntity> _repositoryCompany;

        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IRepository<CompanyEntity> companyRepository, IMapper mapper)
        {
            _repository = repository;
            _repositoryCompany = companyRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity) ?? new UserDto();
        }

        public async Task<IEnumerable<UserDto>> GetAll(Guid companyId)
        {
            var company = await _repositoryCompany.SelectAsync(companyId);
            var listEntity = await _repository.GetAllByCompanyId(companyId);
            return _mapper.Map<IEnumerable<UserDto>>(listEntity);

        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate User)
        {
            var model = _mapper.Map<UserModel>(User);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate User)
        {

            var model = _mapper.Map<UserModel>(User);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserDtoUpdateResult>(result);
        }

        public async Task<IEnumerable<UserDto>> GetAllByCompanyId(Guid companyId)
        {
            var listEntity = await _repository.GetAllByCompanyId(companyId);
            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

    }
}
