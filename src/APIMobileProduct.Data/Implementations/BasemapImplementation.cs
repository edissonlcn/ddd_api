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
    public class BasemapImplementation : BaseRepository<BasemapEntity>, IBasemapRepository
    {
        private DbSet<BasemapEntity> _dataset;

        public BasemapImplementation(OraContext context) : base(context)
        {

            _dataset = context.Set<BasemapEntity>();

        }

        public async Task<IEnumerable<BasemapEntity>> GetAllByCompanyId(Guid id)
        {
            return await _dataset.Where(p => p.CompanyId.Equals(id)).ToListAsync();
        }
    }
}
