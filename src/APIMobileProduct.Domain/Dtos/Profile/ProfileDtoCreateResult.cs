using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Dtos.Permit;

namespace APIMobileProduct.Domain.Dtos.Profile
{
    public class ProfileDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<PermitDtoCreateResult> Permits { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
