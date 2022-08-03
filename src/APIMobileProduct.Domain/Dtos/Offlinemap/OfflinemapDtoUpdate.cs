using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace APIMobileProduct.Domain.Dtos.Offlinemap
{
    public class OfflinemapDtoUpdate
    {

        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Filename { get; set; }


        public string Url { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }


        public Guid CompanyId { get; set; }

        [Required]
        public Guid BasemapId { get; set; }
        public IFormFile File { get; set; }

        [Required]
        public IEnumerable<Guid> GroupsIds { get; set; }
    }
}
