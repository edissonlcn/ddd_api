using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Entities
{
    public class BasemapEntity : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        public string Url { get; set; }
        public string Filename { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        public CompanyEntity Company { get; set; }

    }
}
