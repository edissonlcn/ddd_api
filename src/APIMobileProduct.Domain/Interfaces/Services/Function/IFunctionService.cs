using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Function;

namespace APIMobileProduct.Domain.Interfaces.Services.Function
{
    public interface IFunctionService
    {
        Task<FunctionDto> Get(Guid id);

        Task<IEnumerable<FunctionDto>> GetAll();

        Task<FunctionDtoCreateResult> Post(FunctionDtoCreate company);

        Task<FunctionDtoUpdateResult> Put(FunctionDtoUpdate company);

        Task<bool> Delete(Guid id);
    }
}
