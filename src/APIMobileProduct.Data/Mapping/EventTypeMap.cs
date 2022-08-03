using APIMobileProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMobileProduct.Data.Mapping
{
    public class EventTypeMap
    {
        public void Configure(EntityTypeBuilder<EventTypeEntity> builder)
        {
            builder.ToTable("TIPO_OCORRENCIA");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Codigo).ValueGeneratedOnAdd().UseIdentityColumn();

        }
    }
}
