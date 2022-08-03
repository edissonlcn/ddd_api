using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Entities
{
    public class GroupEntity : BaseEntity
    {
        public GroupEntity()
        {
            this.Profiles = new HashSet<ProfileEntity>();
            this.Offlinemaps = new HashSet<OfflinemapEntity>();

        }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        public IEnumerable<ProfileEntity> Profiles { get; set; }
        public IEnumerable<OfflinemapEntity> Offlinemaps { get; set; }
    }
}
