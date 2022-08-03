using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Entities
{
    public class PermitEntity : BaseEntity
    {
        [Required]
        public bool Consultar { get; set; }

        [Required]
        public bool Cadastrar { get; set; }

        [Required]
        public bool Editar { get; set; }

        [Required]
        public bool Deletar { get; set; }

        [Required]
        public Guid FunctionId { get; set; }
        public FunctionEntity Function { get; set; }

        [Required]
        public Guid ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }

    }
}
