using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Event;

namespace APIMobileProduct.Domain.Interfaces.Services.Event
{
    public interface IEventAliasService
    {
        Task<EventAliasDto> Get(Guid id);
        Task<IEnumerable<EventAliasDto>> GetAll(Guid companyId);
        Task<IEnumerable<EventAliasDto>> GetAllByCompanyId(Guid companyId);

        Task<EventAliasDtoCreateResult> Post(EventAliasDtoCreate eventType);

        Task<EventAliasDtoUpdateResult> Put(EventAliasDtoUpdate eventType);

        Task<bool> Delete(Guid id);
    }
}
