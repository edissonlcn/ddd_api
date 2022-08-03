using System;
using APIMobileProduct.Domain.Entities;

namespace APIMobileProduct.Domain.Dtos.Permit
{
    public class PermitDto
    {
        public Guid Id { get; set; }
        public bool Consultar { get; set; }
        public bool Cadastrar { get; set; }
        public bool Editar { get; set; }
        public bool Deletar { get; set; }
        public Guid FunctionId { get; set; }
        public Guid ProfileId { get; set; }
    }
}
