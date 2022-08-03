using System;
using System.Collections.Generic;
using APIMobileProduct.Domain.Dtos.Profile;

namespace APIMobileProduct.Domain.Dtos.Group
{
    public class GroupDto
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<ProfileDto> Profiles { get; set; }
        public Guid CompanyId { get; set; }
    }
}
