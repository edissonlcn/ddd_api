using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Basemap
{
    public class BasemapDtoUpdateResult
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Filename { get; set; }
    }
}
