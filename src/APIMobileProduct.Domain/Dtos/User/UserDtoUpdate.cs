using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Senha { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Guid GroupId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
