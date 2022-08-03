namespace APIMobileProduct.Domain.Entities
{
    public class EventTypeEntity : BaseEntity
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public int TipoGeometria { get; set; }
        public byte[] File { get; set; }
        public string Filename { get; set; }
    }
}
