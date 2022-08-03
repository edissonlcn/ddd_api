using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Basemap
{
    public class BasemapDtoCreateResult
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Filename { get; set; }
        public string Url { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
