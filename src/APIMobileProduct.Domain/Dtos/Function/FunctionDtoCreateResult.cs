using System;

namespace APIMobileProduct.Domain.Dtos.Function
{
    public class FunctionDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
