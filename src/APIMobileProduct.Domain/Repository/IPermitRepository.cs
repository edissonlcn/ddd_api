using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;

namespace APIMobileProduct.Domain.Repository
{
    public interface IPermitRepository : IRepository<PermitEntity>
    {
        Task<bool> DeleteByProfileId(Guid ProfileId);

    }
}
