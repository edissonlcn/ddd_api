using System;

namespace APIMobileProduct.Domain.Dtos.Function
{
    public class FunctionDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
