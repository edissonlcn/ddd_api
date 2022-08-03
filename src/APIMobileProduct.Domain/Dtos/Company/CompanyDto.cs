using System;

namespace APIMobileProduct.Domain.Dtos.Company
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public byte[] File { get; set; }
        public string Filename { get; set; }
    }
}
