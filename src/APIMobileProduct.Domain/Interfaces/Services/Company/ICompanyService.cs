using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Company;
using APIMobileProduct.Domain.Entities;

namespace APIMobileProduct.Domain.Interfaces.Services.Company
{
    public interface ICompanyService
    {
        Task<CompanyDto> Get(Guid id);

        Task<IEnumerable<CompanyDto>> GetAll();

        Task<CompanyDtoCreateResult> Post(CompanyDtoCreate company);

        Task<CompanyDtoUpdateResult> Put(CompanyDtoUpdate company);

        Task<bool> Delete(Guid id);

    }
}
