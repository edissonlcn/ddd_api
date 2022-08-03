using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMobileProduct.Data.Context;
using APIMobileProduct.Data.Repository;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace APIMobileProduct.Data.Implementations
{
    public class EventAliasImplementation : BaseRepository<EventAliasEntity>, IEventAliasRepository
    {
        private DbSet<EventAliasEntity> _dataset;

        public EventAliasImplementation(OraContext context) : base(context)
        {

            _dataset = context.Set<EventAliasEntity>();

        }

        public async Task<IEnumerable<EventAliasEntity>> GetAllByCompanyId(Guid id)
        {
            return await _dataset.Where(p => p.CompanyId.Equals(id)).ToListAsync();
        }
    }
}
