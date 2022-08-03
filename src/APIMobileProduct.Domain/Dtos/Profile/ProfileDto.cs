using System;
using System.Collections;
using System.Collections.Generic;
using APIMobileProduct.Domain.Dtos.Permit;


namespace APIMobileProduct.Domain.Dtos.Profile
{
    public class ProfileDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Nome { get; set; }
        public IEnumerable<PermitDto> Permits { get; set; }

    }
}
