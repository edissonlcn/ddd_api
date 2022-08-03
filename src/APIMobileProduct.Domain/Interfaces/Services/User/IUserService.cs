using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.User;

namespace APIMobileProduct.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);

        Task<IEnumerable<UserDto>> GetAll(Guid companyId);
        Task<IEnumerable<UserDto>> GetAllByCompanyId(Guid companyId);

        Task<UserDtoCreateResult> Post(UserDtoCreate User);

        Task<UserDtoUpdateResult> Put(UserDtoUpdate User);

        Task<bool> Delete(Guid id);
    }
}
