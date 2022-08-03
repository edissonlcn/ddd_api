using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Function
{
    public class FunctionDtoCreate
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Codigo { get; set; }
    }
}
