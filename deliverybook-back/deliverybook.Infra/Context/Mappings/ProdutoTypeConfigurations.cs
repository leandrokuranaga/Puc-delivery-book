using deliverybook.Domain.Model.Localizacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace deliverybook.Infra.Context.Mappings
{
    public class ProdutoTypeConfigurations : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Descricao).HasColumnType("varchar(max)").IsRequired();
            builder.Property(e => e.Titulo).HasColumnType("varchar(100)");
            builder.Property(e => e.Autores).HasColumnType("varchar(100)");
        }
    }
}