using APIMobileProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMobileProduct.Data.Mapping
{
    public class PermitMap
    {
        public void Configure(EntityTypeBuilder<PermitEntity> builder)
        {
            builder.ToTable("PERMISSAO");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FunctionId).IsRequired();
            builder.Property(c => c.ProfileId).IsRequired();
            builder.Property(c => c.Consultar).IsRequired();
            builder.Property(c => c.Cadastrar).IsRequired();
            builder.Property(c => c.Editar).IsRequired();
            builder.Property(c => c.Deletar).IsRequired();
        }
    }
}
