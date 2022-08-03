using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Entities
{
    public class OfflinemapEntity : BaseEntity
    {
        public OfflinemapEntity()
        {
            this.Groups = new HashSet<GroupEntity>();
        }
        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        public string Url { get; set; }
        public string Filename { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
        [Required]
        public Guid BasemapId { get; set; }
        public BasemapEntity Basemap { get; set; }
        public IEnumerable<GroupEntity> Groups { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }

    }
}
