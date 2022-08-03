using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Company;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;
using APIMobileProduct.Domain.Interfaces.Services.Company;
using APIMobileProduct.Domain.Models;
using AutoMapper;

namespace APIMobileProduct.Service.Services
{
    //Regra de negocio
    public class CompanyService : ICompanyService
    {
        private IRepository<CompanyEntity> _repository;

        private readonly IMapper _mapper;
        public CompanyService(IRepository<CompanyEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CompanyDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CompanyDto>(entity) ?? new CompanyDto();
        }

        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CompanyDto>>(listEntity);
        }

        public async Task<CompanyDtoCreateResult> Post(CompanyDtoCreate company)
        {
            var model = _mapper.Map<CompanyModel>(company);
            var entity = _mapper.Map<CompanyEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CompanyDtoCreateResult>(result);
        }

        public async Task<CompanyDtoUpdateResult> Put(CompanyDtoUpdate company)
        {

            var model = _mapper.Map<CompanyModel>(company);
            var entity = _mapper.Map<CompanyEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<CompanyDtoUpdateResult>(result);
        }
    }
}
