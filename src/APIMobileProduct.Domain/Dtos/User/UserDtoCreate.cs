using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.User
{
    public class UserDtoCreate
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
    }
}
