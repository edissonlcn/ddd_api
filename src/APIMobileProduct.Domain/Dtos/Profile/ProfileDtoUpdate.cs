using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Dtos.Permit;

namespace APIMobileProduct.Domain.Dtos.Profile
{
    public class ProfileDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }
        [Required]
        public IEnumerable<PermitDtoUpdate> Permits { get; set; }
    }
}
