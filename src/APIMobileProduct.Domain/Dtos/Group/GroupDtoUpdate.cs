using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Entities;

namespace APIMobileProduct.Domain.Dtos.Group
{
    public class GroupDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public IEnumerable<Guid> ProfilesIds { get; set; }

        public Guid CompanyId { get; set; }
    }
}
