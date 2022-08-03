using System.Web;
namespace APIMobileProduct.Domain.Entities
{
    public class CompanyEntity : BaseEntity
    {
        public string Nome { get; set; }

        public byte[] File { get; set; }
        public string Filename { get; set; }

    }
}
