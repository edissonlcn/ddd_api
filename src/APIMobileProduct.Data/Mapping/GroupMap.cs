using APIMobileProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMobileProduct.Data.Mapping
{
    public class GroupMap
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder.ToTable("GRUPO");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(255);
            builder.Property(c => c.CompanyId).IsRequired();
            builder.HasMany<ProfileEntity>(g => g.Profiles).WithMany(c => c.Groups);
            builder.HasMany<OfflinemapEntity>(g => g.Offlinemaps).WithMany(c => c.Groups);
        }
    }
}
