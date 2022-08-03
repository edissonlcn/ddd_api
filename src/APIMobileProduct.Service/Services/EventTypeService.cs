using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Event;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;
using APIMobileProduct.Domain.Interfaces.Services.Event;
using APIMobileProduct.Domain.Models;
using AutoMapper;

namespace APIMobileProduct.Service.Services
{
    //Regra de negocio
    public class EventTypeService : IEventTypeService
    {
        private IRepository<EventTypeEntity> _repository;

        private readonly IMapper _mapper;
        public EventTypeService(IRepository<EventTypeEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<EventTypeDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<EventTypeDto>(entity) ?? new EventTypeDto();
        }

        public async Task<IEnumerable<EventTypeDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<EventTypeDto>>(listEntity);
        }

        public async Task<EventTypeDtoCreateResult> Post(EventTypeDtoCreate EventType)
        {
            var model = _mapper.Map<EventTypeModel>(EventType);
            var entity = _mapper.Map<EventTypeEntity>(model);

            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<EventTypeDtoCreateResult>(result);
        }

        public async Task<EventTypeDtoUpdateResult> Put(EventTypeDtoUpdate EventType)
        {

            var model = _mapper.Map<EventTypeModel>(EventType);
            var entity = _mapper.Map<EventTypeEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<EventTypeDtoUpdateResult>(result);
        }

    }
}
