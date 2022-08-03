using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace APIMobileProduct.Domain.Dtos.Basemap
{
    public class BasemapDtoCreate
    {

        [Required]
        public string Nome { get; set; }


        public string Url { get; set; }


        public Guid CompanyId { get; set; }
        public string Filename { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}
