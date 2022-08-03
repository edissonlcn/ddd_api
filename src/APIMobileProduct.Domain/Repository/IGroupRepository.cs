using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;

namespace APIMobileProduct.Domain.Repository
{
    public interface IGroupRepository : IRepository<GroupEntity>
    {
        new Task<IEnumerable<GroupEntity>> SelectAsync();
        new Task<GroupEntity> UpdateAsync(GroupEntity item);
        Task<IEnumerable<GroupEntity>> GetAllByCompanyId(Guid id);
        Task<IEnumerable<GroupEntity>> GetAllOfflinemaps(Guid id);
        Task<IEnumerable<GroupEntity>> SelectByIds(IEnumerable<Guid> id);
    }
}
