using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Dtos.Profile;
using APIMobileProduct.Domain.Entities;

namespace APIMobileProduct.Domain.Dtos.Group
{
    public class GroupDtoCreate
    {

        [Required]
        public string Nome { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        [Required]
        public IEnumerable<Guid> ProfilesIds { get; set; }


    }
}
