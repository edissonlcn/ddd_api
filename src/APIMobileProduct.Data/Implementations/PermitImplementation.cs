using System;
using System.Linq;
using System.Threading.Tasks;
using APIMobileProduct.Data.Context;
using APIMobileProduct.Data.Repository;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace APIMobileProduct.Data.Implementations
{
    public class PermitImplementation : BaseRepository<PermitEntity>, IPermitRepository
    {
        private DbSet<PermitEntity> _dataset;

        public PermitImplementation(OraContext context) : base(context)
        {

            _dataset = context.Set<PermitEntity>();

        }
        public async Task<bool> DeleteByProfileId(Guid ProfileId)
        {
            try
            {
                _dataset.RemoveRange(_dataset.Where(p => p.ProfileId == ProfileId));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
