using System;

namespace APIMobileProduct.Domain.Dtos.Company
{
    public class CompanyDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
