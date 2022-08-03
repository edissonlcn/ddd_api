using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Entities
{
    public class UserEntity : BaseEntity
    {

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(16)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public Guid GroupId { get; set; }

        [Required]
        public GroupEntity Group { get; set; }

        [Required]
        public Guid CompanyId { get; set; }
    }
}
