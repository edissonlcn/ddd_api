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
    public class OfflinemapImplementation : BaseRepository<OfflinemapEntity>, IOfflinemapRepository
    {
        private DbSet<OfflinemapEntity> _dataset;

        public OfflinemapImplementation(OraContext context) : base(context)
        {

            _dataset = context.Set<OfflinemapEntity>();

        }

        public new async Task<IEnumerable<OfflinemapEntity>> SelectAsync()
        {
            return await _dataset.Include(p => p.Groups).ToListAsync();
        }
        public async Task<IEnumerable<OfflinemapEntity>> SelectPendingAsync()
        {
            return await _dataset.Include(p => p.Basemap).Where(p => string.IsNullOrEmpty(p.Url) == true).ToListAsync();
        }
        public async Task<IEnumerable<OfflinemapEntity>> SelectPendingByIdAsync(Guid id)
        {
            return await _dataset.Include(p => p.Basemap).Where(p => p.Id.Equals(id)).ToListAsync();
        }

        public async Task<IEnumerable<OfflinemapEntity>> GetAllByCompanyId(Guid id)
        {
            return await _dataset.Where(p => p.CompanyId.Equals(id)).ToListAsync();
        }

        public async Task<IEnumerable<OfflinemapEntity>> GetAll(Guid id)
        {
            return await _dataset.Where(p => p.CompanyId.Equals(id)).ToListAsync();
        }

        public new async Task<OfflinemapEntity> UpdateAsync(OfflinemapEntity item)
        {
            try
            {
                var result = await _dataset.Include(p => p.Groups).SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                {
                    return null;
                }
                item.Url = string.IsNullOrEmpty(item.Url) ? result.Url : item.Url;
                item.Latitude = item.Latitude == null || item.Latitude == 0 ? result.Latitude : item.Latitude;
                item.Longitude = item.Longitude == null || item.Longitude == 0 ? result.Longitude : item.Longitude;
                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;
                result.Groups = item.Groups;
                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<OfflinemapEntity> UpdateCoordsAsync(OfflinemapEntity item)
        {
            try
            {
                var result = await _dataset.Include(p => p.Groups).SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                {
                    return null;
                }
                result.Url = item.Url;
                result.Latitude = item.Latitude;
                result.Longitude = item.Longitude;
                _context.Entry(result).CurrentValues.SetValues(result);
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
