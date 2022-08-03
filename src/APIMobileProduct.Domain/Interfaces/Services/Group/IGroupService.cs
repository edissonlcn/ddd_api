using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Group;

namespace APIMobileProduct.Domain.Interfaces.Services.Group
{
    public interface IGroupService
    {
        Task<GroupDto> Get(Guid id);

        Task<IEnumerable<GroupDto>> GetAll(Guid companyId);
        Task<IEnumerable<GroupDto>> GetAllByCompanyId(Guid companyId);
        Task<IEnumerable<GroupOfflinemapsDto>> GetAllOfflinemaps(Guid id);
        Task<GroupDtoCreateResult> Post(GroupDtoCreate Group);
        Task<GroupDtoUpdateResult> Put(GroupDtoUpdate Group);

        Task<bool> Delete(Guid id);
    }
}
