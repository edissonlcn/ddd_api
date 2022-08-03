using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Offlinemap;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;
using APIMobileProduct.Domain.Interfaces.Services.Offlinemap;
using APIMobileProduct.Domain.Models;
using APIMobileProduct.Domain.Repository;
using AutoMapper;

namespace APIMobileProduct.Service.Services
{
    //Regra de negocio
    public class OfflinemapService : IOfflinemapService
    {
        private IOfflinemapRepository _repository;
        private IRepository<CompanyEntity> _repositoryCompany;
        private IGroupRepository _repositoryGroup;

        private readonly IMapper _mapper;
        public OfflinemapService(IOfflinemapRepository repository, IRepository<CompanyEntity> companyRepository, IGroupRepository repositoryGroup, IMapper mapper)
        {
            _repository = repository;
            _repositoryCompany = companyRepository;
            _repositoryGroup = repositoryGroup;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<OfflinemapDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<OfflinemapDto>(entity) ?? new OfflinemapDto();
        }

        public async Task<IEnumerable<OfflinemapDto>> GetAll(Guid companyId)
        {
            var company = await _repositoryCompany.SelectAsync(companyId);


            var listEntity = await _repository.GetAllByCompanyId(companyId);
            return _mapper.Map<IEnumerable<OfflinemapDto>>(listEntity);

        }

        public async Task<IEnumerable<OfflinemapDtoPendingResult>> GetPending()
        {
            var listEntity = await _repository.SelectPendingAsync();
            return _mapper.Map<IEnumerable<OfflinemapDtoPendingResult>>(listEntity);
        }

        public async Task<IEnumerable<OfflinemapDtoPendingResult>> GetPendingById(Guid id)
        {
            var listEntity = await _repository.SelectPendingByIdAsync(id);
            return _mapper.Map<IEnumerable<OfflinemapDtoPendingResult>>(listEntity);
        }


        public async Task<OfflinemapDtoCreateResult> Post(OfflinemapDtoCreate Offlinemap)
        {
            var model = _mapper.Map<OfflinemapModel>(Offlinemap);
            var entity = _mapper.Map<OfflinemapEntity>(model);
            entity.Groups = await _repositoryGroup.SelectByIds(Offlinemap.GroupsIds);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<OfflinemapDtoCreateResult>(result);
        }

        public async Task<OfflinemapDtoUpdateResult> Put(OfflinemapDtoUpdate Offlinemap)
        {

            var model = _mapper.Map<OfflinemapModel>(Offlinemap);
            var entity = _mapper.Map<OfflinemapEntity>(model);
            entity.Groups = await _repositoryGroup.SelectByIds(Offlinemap.GroupsIds);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<OfflinemapDtoUpdateResult>(result);
        }

        public async Task<OfflinemapDtoUpdateResult> PutCoords(OfflinemapDtoUpdateCoords Offlinemap)
        {

            var model = _mapper.Map<OfflinemapModel>(Offlinemap);
            var entity = _mapper.Map<OfflinemapEntity>(model);
            var result = await _repository.UpdateCoordsAsync(entity);

            return _mapper.Map<OfflinemapDtoUpdateResult>(result);
        }

        public async Task<IEnumerable<OfflinemapDto>> GetAllByCompanyId(Guid companyId)
        {
            var listEntity = await _repository.GetAllByCompanyId(companyId);
            return _mapper.Map<IEnumerable<OfflinemapDto>>(listEntity); ;
        }
    }
}
