using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIMobileProduct.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace APIMobileProduct.Domain.Dtos.Offlinemap
{
    public class OfflinemapDtoUpdateCoords
    {

        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}
