using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Company
{
    public class CompanyDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public byte[] File { get; set; }
        [Required]
        public string Filename { get; set; }
    }
}
