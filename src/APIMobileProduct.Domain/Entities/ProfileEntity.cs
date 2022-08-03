using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Entities
{
    public class ProfileEntity : BaseEntity
    {

        public ProfileEntity()
        {
            this.Groups = new HashSet<GroupEntity>();
        }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        public CompanyEntity Company { get; set; }

        public IEnumerable<GroupEntity> Groups { get; set; }
        public IEnumerable<PermitEntity> Permits { get; set; }


    }
}
