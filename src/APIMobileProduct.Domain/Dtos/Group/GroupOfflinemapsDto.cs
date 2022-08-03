using System;
using System.Collections.Generic;
using APIMobileProduct.Domain.Dtos.Offlinemap;
using APIMobileProduct.Domain.Entities;

namespace APIMobileProduct.Domain.Dtos.Group
{
    public class GroupOfflinemapsDto
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid CompanyId { get; set; }
        public IEnumerable<OfflinemapDto> Offlinemaps { get; set; }
    }
}
