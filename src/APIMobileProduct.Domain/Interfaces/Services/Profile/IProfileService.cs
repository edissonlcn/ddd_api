using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Profile;

namespace APIMobileProduct.Domain.Interfaces.Services.Profile
{
    public interface IProfileService
    {
        Task<ProfileDto> Get(Guid id);

        Task<IEnumerable<ProfileDto>> GetAll(Guid companyId);
        Task<IEnumerable<ProfileDto>> GetAllByCompanyId(Guid companyId);

        Task<ProfileDtoCreateResult> Post(ProfileDtoCreate Profile);

        Task<ProfileDtoUpdateResult> Put(ProfileDtoUpdate Profile);

        Task<bool> Delete(Guid id);
    }
}
