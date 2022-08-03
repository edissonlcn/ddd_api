using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Basemap;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;
using APIMobileProduct.Domain.Interfaces.Services.Basemap;
using APIMobileProduct.Domain.Models;
using APIMobileProduct.Domain.Repository;
using AutoMapper;

namespace APIMobileProduct.Service.Services
{
    //Regra de negocio
    public class BasemapService : IBasemapService
    {
        private IBasemapRepository _repository;
        private IRepository<CompanyEntity> _repositoryCompany;

        private readonly IMapper _mapper;
        public BasemapService(IBasemapRepository repository, IRepository<CompanyEntity> companyRepository, IMapper mapper)
        {
            _repository = repository;
            _repositoryCompany = companyRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<BasemapDto> Get(Guid id)
        {

            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<BasemapDto>(entity) ?? new BasemapDto();
        }

        public async Task<IEnumerable<BasemapDto>> GetAll(Guid companyId)
        {
            var company = await _repositoryCompany.SelectAsync(companyId);

            if (company.Nome.ToUpper().Contains("CTC"))
            {
                var listEntity = await _repository.SelectAsync();
                return _mapper.Map<IEnumerable<BasemapDto>>(listEntity);
            }
            else
            {
                var listEntity = await _repository.GetAllByCompanyId(company.Id);
                return _mapper.Map<IEnumerable<BasemapDto>>(listEntity);
            }
        }

        public async Task<BasemapDtoCreateResult> Post(BasemapDtoCreate Basemap)
        {
            var model = _mapper.Map<BasemapModel>(Basemap);
            var entity = _mapper.Map<BasemapEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<BasemapDtoCreateResult>(result);
        }

        public async Task<BasemapDtoUpdateResult> Put(BasemapDtoUpdate Basemap)
        {

            var model = _mapper.Map<BasemapModel>(Basemap);
            var entity = _mapper.Map<BasemapEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<BasemapDtoUpdateResult>(result);
        }

        public async Task<IEnumerable<BasemapDto>> GetAllByCompanyId(Guid companyId)
        {
            var listEntity = await _repository.GetAllByCompanyId(companyId);
            return _mapper.Map<IEnumerable<BasemapDto>>(listEntity);
        }
    }
}
