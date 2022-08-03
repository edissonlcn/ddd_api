using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;

namespace APIMobileProduct.Domain.Repository
{
    public interface IEventAliasRepository : IRepository<EventAliasEntity>
    {
        Task<IEnumerable<EventAliasEntity>> GetAllByCompanyId(Guid id);
    }
}
