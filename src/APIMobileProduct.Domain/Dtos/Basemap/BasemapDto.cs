using System;

namespace APIMobileProduct.Domain.Dtos.Basemap
{
    public class BasemapDto
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Filename { get; set; }
        public string Url { get; set; }
        public Guid CompanyId { get; set; }
    }
}
