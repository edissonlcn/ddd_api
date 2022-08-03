using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;

namespace APIMobileProduct.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email, string senha);
        Task<IEnumerable<UserEntity>> GetAllByCompanyId(Guid id);

    }
}
