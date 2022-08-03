using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace APIMobileProduct.Domain.Dtos.Basemap
{
    public class BasemapDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }

        public string Url { get; set; }

        public Guid CompanyId { get; set; }
        public string Filename { get; set; }

        public IFormFile File { get; set; }
    }
}
