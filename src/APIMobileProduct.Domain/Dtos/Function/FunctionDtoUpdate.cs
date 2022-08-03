using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Function
{
    public class FunctionDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
