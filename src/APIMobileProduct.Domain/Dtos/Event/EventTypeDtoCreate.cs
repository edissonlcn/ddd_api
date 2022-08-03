using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Event
{
    public class EventTypeDtoCreate
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int TipoGeometria { get; set; }
        public byte[] File { get; set; }
        public string Filename { get; set; }
    }
}
