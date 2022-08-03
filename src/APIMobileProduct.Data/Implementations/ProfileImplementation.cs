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
    public class ProfileImplementation : BaseRepository<ProfileEntity>, IProfileRepository
    {
        private DbSet<ProfileEntity> _dataset;

        public ProfileImplementation(OraContext context) : base(context)
        {

            _dataset = context.Set<ProfileEntity>();

        }

        public new async Task<IEnumerable<ProfileEntity>> SelectAsync()
        {
            return await _dataset.Include(p => p.Permits).ToListAsync();
        }



        public async Task<IEnumerable<ProfileEntity>> GetAllByCompanyId(Guid id)
        {
            return await _dataset.Include(p => p.Permits).Where(p => p.CompanyId.Equals(id)).ToListAsync();
        }

        public async Task<IEnumerable<ProfileEntity>> SelectByIds(IEnumerable<Guid> Ids)
        {
            return await _dataset.Where(p => Ids.Contains(p.Id)).ToListAsync();
        }
    }
}
