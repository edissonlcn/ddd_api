using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Event;

namespace APIMobileProduct.Domain.Interfaces.Services.Event
{
    public interface IEventTypeService
    {
        Task<EventTypeDto> Get(Guid id);

        Task<IEnumerable<EventTypeDto>> GetAll();

        Task<EventTypeDtoCreateResult> Post(EventTypeDtoCreate eventType);

        Task<EventTypeDtoUpdateResult> Put(EventTypeDtoUpdate eventType);

        Task<bool> Delete(Guid id);
    }
}
