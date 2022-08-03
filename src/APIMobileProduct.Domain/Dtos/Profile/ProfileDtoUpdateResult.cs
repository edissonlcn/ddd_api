using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Dtos.Permit;

namespace APIMobileProduct.Domain.Dtos.Profile
{
    public class ProfileDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<PermitDtoUpdateResult> Permits { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
