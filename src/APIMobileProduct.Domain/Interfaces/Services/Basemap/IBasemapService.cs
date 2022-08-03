using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Basemap;

namespace APIMobileProduct.Domain.Interfaces.Services.Basemap
{
    public interface IBasemapService
    {
        Task<BasemapDto> Get(Guid id);

        Task<IEnumerable<BasemapDto>> GetAll(Guid companyId);
        Task<IEnumerable<BasemapDto>> GetAllByCompanyId(Guid companyId);

        Task<BasemapDtoCreateResult> Post(BasemapDtoCreate Basemap);

        Task<BasemapDtoUpdateResult> Put(BasemapDtoUpdate Basemap);

        Task<bool> Delete(Guid id);
    }
}
