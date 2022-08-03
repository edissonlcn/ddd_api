using APIMobileProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMobileProduct.Data.Mapping
{
    public class OfflinemapMap
    {
        public void Configure(EntityTypeBuilder<OfflinemapEntity> builder)
        {
            builder.ToTable("MAPA_OFFLINE");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(255);
            builder.Property(c => c.CompanyId).IsRequired();
            builder.HasMany<GroupEntity>(g => g.Groups).WithMany(c => c.Offlinemaps);

        }
    }
}
