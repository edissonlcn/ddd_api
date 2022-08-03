using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;

namespace APIMobileProduct.Domain.Repository
{
    public interface IOfflinemapRepository : IRepository<OfflinemapEntity>
    {
        new Task<IEnumerable<OfflinemapEntity>> SelectAsync();
        Task<IEnumerable<OfflinemapEntity>> SelectPendingAsync();
        Task<IEnumerable<OfflinemapEntity>> SelectPendingByIdAsync(Guid id);
        new Task<OfflinemapEntity> UpdateAsync(OfflinemapEntity item);
        Task<OfflinemapEntity> UpdateCoordsAsync(OfflinemapEntity item);
        Task<IEnumerable<OfflinemapEntity>> GetAllByCompanyId(Guid id);
    }
}
