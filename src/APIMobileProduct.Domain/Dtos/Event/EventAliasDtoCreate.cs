using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Event
{
    public class EventAliasDtoCreate
    {
        [Required]
        public string Field { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public string Type { get; set; }
        public Guid CompanyId { get; set; }

    }
}
