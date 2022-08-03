using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Permit
{
    public class PermitDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
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
        [Required]
        public Guid ProfileId { get; set; }

    }
}
