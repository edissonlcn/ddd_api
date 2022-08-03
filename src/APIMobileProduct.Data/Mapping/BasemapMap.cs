using APIMobileProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMobileProduct.Data.Mapping
{
    public class BasemapMap
    {
        public void Configure(EntityTypeBuilder<BasemapEntity> builder)
        {
            builder.ToTable("MAPA_BASE");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(255);
            builder.Property(c => c.CompanyId).IsRequired();
        }
    }
}
