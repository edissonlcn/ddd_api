using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Offlinemap;

namespace APIMobileProduct.Domain.Interfaces.Services.Offlinemap
{
    public interface IOfflinemapService
    {
        Task<OfflinemapDto> Get(Guid id);

        Task<IEnumerable<OfflinemapDto>> GetAll(Guid companyId);
        Task<IEnumerable<OfflinemapDtoPendingResult>> GetPending();
        Task<IEnumerable<OfflinemapDtoPendingResult>> GetPendingById(Guid id);
        Task<IEnumerable<OfflinemapDto>> GetAllByCompanyId(Guid companyId);

        Task<OfflinemapDtoCreateResult> Post(OfflinemapDtoCreate Offlinemap);

        Task<OfflinemapDtoUpdateResult> Put(OfflinemapDtoUpdate Offlinemap);
        Task<OfflinemapDtoUpdateResult> PutCoords(OfflinemapDtoUpdateCoords Offlinemap);

        Task<bool> Delete(Guid id);
    }
}
