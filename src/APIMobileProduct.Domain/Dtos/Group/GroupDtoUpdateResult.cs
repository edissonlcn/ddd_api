using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Dtos.Profile;

namespace APIMobileProduct.Domain.Dtos.Group
{
    public class GroupDtoUpdateResult
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<ProfileDto> Profiles { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
