using System;

namespace APIMobileProduct.Domain.Dtos.Event
{
    public class EventTypeDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public int TipoGeometria { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
