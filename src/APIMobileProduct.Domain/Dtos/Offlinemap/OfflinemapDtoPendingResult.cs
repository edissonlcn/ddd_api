using System;
using APIMobileProduct.Domain.Entities;

namespace APIMobileProduct.Domain.Dtos.Offlinemap
{
    public class OfflinemapDtoPendingResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public string Filename { get; set; }
        public Guid BasemapId { get; set; }
        public BasemapEntity Basemap { get; set; }
    }
}
