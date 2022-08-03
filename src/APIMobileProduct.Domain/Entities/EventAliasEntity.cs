using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Entities
{
    public class EventAliasEntity : BaseEntity
    {
        public string Field { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
    }
}
