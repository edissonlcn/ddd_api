using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Group;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;
using APIMobileProduct.Domain.Interfaces.Services.Group;
using APIMobileProduct.Domain.Models;
using APIMobileProduct.Domain.Repository;
using AutoMapper;

namespace APIMobileProduct.Service.Services
{
    //Regra de negocio
    public class GroupService : IGroupService
    {
        private IGroupRepository _repository;
        private IProfileRepository _repositoryProfile;
        private IRepository<CompanyEntity> _repositoryCompany;

        private readonly IMapper _mapper;
        public GroupService(IGroupRepository repository, IRepository<CompanyEntity> companyRepository, IProfileRepository repositoryProfile, IMapper mapper)
        {
            _repository = repository;
            _repositoryCompany = companyRepository;
            _repositoryProfile = repositoryProfile;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<GroupDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<GroupDto>(entity) ?? new GroupDto();
        }

        public async Task<IEnumerable<GroupDto>> GetAll(Guid companyId)
        {
            var company = await _repositoryCompany.SelectAsync(companyId);


            var listEntity = await _repository.GetAllByCompanyId(companyId);
            return _mapper.Map<IEnumerable<GroupDto>>(listEntity);




        }

        public async Task<GroupDtoCreateResult> Post(GroupDtoCreate Group)
        {
            var model = _mapper.Map<GroupModel>(Group);
            var entity = _mapper.Map<GroupEntity>(model);

            var listProfiles = await _repositoryProfile.SelectByIds(Group.ProfilesIds);
            entity.Profiles = listProfiles;
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<GroupDtoCreateResult>(result);
        }

        public async Task<GroupDtoUpdateResult> Put(GroupDtoUpdate Group)
        {

            var model = _mapper.Map<GroupModel>(Group);
            var entity = _mapper.Map<GroupEntity>(model);
            var listProfiles = await _repositoryProfile.SelectByIds(Group.ProfilesIds);
            entity.Profiles = listProfiles;
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<GroupDtoUpdateResult>(result);
        }

        public async Task<IEnumerable<GroupDto>> GetAllByCompanyId(Guid companyId)
        {
            var listEntity = await _repository.GetAllByCompanyId(companyId);
            return _mapper.Map<IEnumerable<GroupDto>>(listEntity); ;
        }

        public async Task<IEnumerable<GroupOfflinemapsDto>> GetAllOfflinemaps(Guid id)
        {
            var listEntity = await _repository.GetAllOfflinemaps(id);
            return _mapper.Map<IEnumerable<GroupOfflinemapsDto>>(listEntity);
        }
    }
}
