using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;

namespace APIMobileProduct.Domain.Repository
{
    public interface IProfileRepository : IRepository<ProfileEntity>
    {
        new Task<IEnumerable<ProfileEntity>> SelectAsync();
        Task<IEnumerable<ProfileEntity>> GetAllByCompanyId(Guid id);

        Task<IEnumerable<ProfileEntity>> SelectByIds(IEnumerable<Guid> id);
    }
}
