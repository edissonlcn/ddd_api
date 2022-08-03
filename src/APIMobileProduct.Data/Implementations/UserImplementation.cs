using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using APIMobileProduct.Data.Context;
using APIMobileProduct.Data.Repository;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace APIMobileProduct.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(OraContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email, string senha)
        {
            return await _dataset.Include(u => u.Group)
                                  .Include(u => u.Group.Profiles)
                                  .ThenInclude(p => p.Permits)
                                  .FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }

        public async Task<IEnumerable<UserEntity>> GetAllByCompanyId(Guid id)
        {
            return await _dataset.Where(p => p.CompanyId.Equals(id)).ToListAsync();
        }
    }
}
