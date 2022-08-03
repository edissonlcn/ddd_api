using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Profile;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;
using APIMobileProduct.Domain.Interfaces.Services.Profile;
using APIMobileProduct.Domain.Models;
using APIMobileProduct.Domain.Repository;
using AutoMapper;

namespace APIMobileProduct.Service.Services
{
    //Regra de negocio
    public class ProfileService : IProfileService
    {
        private IProfileRepository _repository;
        private IRepository<CompanyEntity> _repositoryCompany;
        private IPermitRepository _repositoryPermit;

        private readonly IMapper _mapper;
        public ProfileService(IProfileRepository repository, IPermitRepository repositoryPermit, IRepository<CompanyEntity> companyRepository, IMapper mapper)
        {
            _repository = repository;
            _repositoryPermit = repositoryPermit;
            _repositoryCompany = companyRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProfileDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ProfileDto>(entity) ?? new ProfileDto();
        }

        public async Task<IEnumerable<ProfileDto>> GetAll(Guid companyId)
        {
            var company = await _repositoryCompany.SelectAsync(companyId);

            var listEntity = await _repository.GetAllByCompanyId(companyId);
            return _mapper.Map<IEnumerable<ProfileDto>>(listEntity);



        }

        public async Task<IEnumerable<ProfileDto>> GetAllByCompanyId(Guid companyId)
        {
            var listEntity = await _repository.GetAllByCompanyId(companyId);
            return _mapper.Map<IEnumerable<ProfileDto>>(listEntity);
        }

        public async Task<ProfileDtoCreateResult> Post(ProfileDtoCreate Profile)
        {
            var model = _mapper.Map<ProfileModel>(Profile);
            var entity = _mapper.Map<ProfileEntity>(model);
            var result = await _repository.InsertAsync(entity);
            foreach (var permit in Profile.Permits)
            {
                permit.ProfileId = (Guid)result.Id;
                var permitModel = _mapper.Map<PermitModel>(permit);
                var permitEntity = _mapper.Map<PermitEntity>(permitModel);

                await _repositoryPermit.InsertAsync(permitEntity);

            }
            return _mapper.Map<ProfileDtoCreateResult>(result);
        }

        public async Task<ProfileDtoUpdateResult> Put(ProfileDtoUpdate Profile)
        {

            var model = _mapper.Map<ProfileModel>(Profile);
            var entity = _mapper.Map<ProfileEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            if (await _repositoryPermit.DeleteByProfileId(Profile.Id))
            {
                foreach (var permit in Profile.Permits)
                {
                    permit.ProfileId = (Guid)result.Id;
                    var permitModel = _mapper.Map<PermitModel>(permit);
                    var permitEntity = _mapper.Map<PermitEntity>(permitModel);

                    await _repositoryPermit.InsertAsync(permitEntity);

                }
            }

            return _mapper.Map<ProfileDtoUpdateResult>(result);
        }


    }
}
