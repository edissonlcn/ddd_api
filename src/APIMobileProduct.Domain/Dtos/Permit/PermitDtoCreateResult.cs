using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Permit
{
    public class PermitDtoCreateResult
    {

        public bool Consultar { get; set; }

        public bool Cadastrar { get; set; }

        public bool Editar { get; set; }

        public bool Deletar { get; set; }

        public Guid FunctionId { get; set; }

        public Guid ProfileId { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
