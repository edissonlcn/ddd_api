using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Company
{
    public class CompanyDtoCreate
    {
        [Required]
        public string Nome { get; set; }

        public byte[] File { get; set; }
        public string Filename { get; set; }

    }
}
