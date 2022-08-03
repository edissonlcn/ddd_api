using APIMobileProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMobileProduct.Data.Mapping
{
    public class EventAliasMap
    {
        public void Configure(EntityTypeBuilder<EventAliasEntity> builder)
        {
            builder.ToTable("ALIAS_OCORRENCIA");
            builder.HasKey(c => c.Id);

        }
    }
}
