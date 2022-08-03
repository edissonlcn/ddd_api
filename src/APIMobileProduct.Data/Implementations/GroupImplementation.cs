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
    public class GroupImplementation : BaseRepository<GroupEntity>, IGroupRepository
    {
        private DbSet<GroupEntity> _dataset;

        public GroupImplementation(OraContext context) : base(context)
        {

            _dataset = context.Set<GroupEntity>();

        }

        public new async Task<IEnumerable<GroupEntity>> SelectAsync()
        {
            return await _dataset.Include(p => p.Profiles).ToListAsync();
        }

        public async Task<IEnumerable<GroupEntity>> GetAllByCompanyId(Guid id)
        {
            return await _dataset.Include(g => g.Profiles)
                        .ThenInclude(p => p.Permits)
                        .Where(p => p.CompanyId.Equals(id)).ToListAsync();

        }

        public async Task<IEnumerable<GroupEntity>> SelectByIds(IEnumerable<Guid> Ids)
        {
            return await _dataset.Where(p => Ids.Contains(p.Id)).ToListAsync();
        }

        public async Task<IEnumerable<GroupEntity>> GetAllOfflinemaps(Guid id)
        {
            return await _dataset.Include(p => p.Offlinemaps).Where(p => p.Id.Equals(id)).ToListAsync();
        }

        public new async Task<GroupEntity> UpdateAsync(GroupEntity item)
        {
            try
            {
                var result = await _dataset.Include(p => p.Profiles).SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                {
                    return null;
                }

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;
                result.Profiles = item.Profiles;
                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
