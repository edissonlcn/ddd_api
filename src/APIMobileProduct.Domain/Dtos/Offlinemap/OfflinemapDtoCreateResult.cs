using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Dtos.Group;
using APIMobileProduct.Domain.Entities;

namespace APIMobileProduct.Domain.Dtos.Offlinemap
{
    public class OfflinemapDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public string Filename { get; set; }
        public Guid CompanyId { get; set; }
        public Guid BasemapId { get; set; }
        public IEnumerable<GroupDto> Groups { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
