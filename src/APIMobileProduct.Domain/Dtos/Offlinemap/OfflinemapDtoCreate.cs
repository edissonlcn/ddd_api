using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace APIMobileProduct.Domain.Dtos.Offlinemap
{
    public class OfflinemapDtoCreate
    {

        [Required]
        public string Nome { get; set; }


        public string Url { get; set; }
        public string Filename { get; set; }


        public Guid CompanyId { get; set; }
        [Required]
        public Guid BasemapId { get; set; }
        [Required]
        public IFormFile File { get; set; }


        public IEnumerable<Guid> GroupsIds { get; set; }
    }
}
