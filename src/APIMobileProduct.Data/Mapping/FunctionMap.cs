using APIMobileProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMobileProduct.Data.Mapping
{
    public class FunctionMap
    {
        public void Configure(EntityTypeBuilder<FunctionEntity> builder)
        {
            builder.ToTable("FUNCAO");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Codigo).IsRequired();
        }
    }
}
