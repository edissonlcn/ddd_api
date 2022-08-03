using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Event;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;
using APIMobileProduct.Domain.Interfaces.Services.Event;
using APIMobileProduct.Domain.Models;
using APIMobileProduct.Domain.Repository;
using AutoMapper;

namespace APIMobileProduct.Service.Services
{
    //Regra de negocio
    public class EventAliasService : IEventAliasService
    {
        private IEventAliasRepository _repository;
        private IRepository<CompanyEntity> _repositoryCompany;

        private readonly IMapper _mapper;
        public EventAliasService(IEventAliasRepository repository, IRepository<CompanyEntity> companyRepository, IMapper mapper)
        {
            _repository = repository;
            _repositoryCompany = companyRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<EventAliasDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<EventAliasDto>(entity) ?? new EventAliasDto();
        }


        public async Task<EventAliasDtoCreateResult> Post(EventAliasDtoCreate EventAlias)
        {
            var model = _mapper.Map<EventAliasModel>(EventAlias);
            var entity = _mapper.Map<EventAliasEntity>(model);

            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<EventAliasDtoCreateResult>(result);
        }

        public async Task<EventAliasDtoUpdateResult> Put(EventAliasDtoUpdate EventAlias)
        {

            var model = _mapper.Map<EventAliasModel>(EventAlias);
            var entity = _mapper.Map<EventAliasEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<EventAliasDtoUpdateResult>(result);
        }

        public async Task<IEnumerable<EventAliasDto>> GetAll(Guid companyId)
        {
            var company = await _repositoryCompany.SelectAsync(companyId);


            var listEntity = await _repository.GetAllByCompanyId(company.Id);
            return _mapper.Map<IEnumerable<EventAliasDto>>(listEntity);

        }

        public async Task<IEnumerable<EventAliasDto>> GetAllByCompanyId(Guid companyId)
        {
            var listEntity = await _repository.GetAllByCompanyId(companyId);
            return _mapper.Map<IEnumerable<EventAliasDto>>(listEntity);
        }


    }
}
