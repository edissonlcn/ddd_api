using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Dtos.Group;
using APIMobileProduct.Domain.Entities;

namespace APIMobileProduct.Domain.Dtos.Offlinemap
{
    public class OfflinemapDto
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Filename { get; set; }


        public string Url { get; set; }


        public Guid CompanyId { get; set; }
        public Guid BasemapId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }


        public IEnumerable<GroupDto> Groups { get; set; }
    }
}
