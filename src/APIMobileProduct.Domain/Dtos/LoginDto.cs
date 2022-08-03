using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é campo obrigatório para login.")]
        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        [StringLength(255, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
