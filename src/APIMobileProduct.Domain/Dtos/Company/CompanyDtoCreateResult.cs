using System;

namespace APIMobileProduct.Domain.Dtos.Company
{
    public class CompanyDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
