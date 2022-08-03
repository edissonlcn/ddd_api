using System;

namespace APIMobileProduct.Domain.Dtos.Event
{
    public class EventTypeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public int TipoGeometria { get; set; }
        public byte[] File { get; set; }
        public string Filename { get; set; }
    }
}
