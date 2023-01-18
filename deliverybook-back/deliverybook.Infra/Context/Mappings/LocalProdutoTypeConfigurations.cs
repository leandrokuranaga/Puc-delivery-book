using deliverybook.Domain.Model.Localizacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace deliverybook.Infra.Context.Mappings
{
    public class LocalProdutoTypeConfigurations : IEntityTypeConfiguration<LocalProduto>
    {
        public void Configure(EntityTypeBuilder<LocalProduto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Disponivel).HasDefaultValue(true);
            builder.Property(e => e.LocalId).IsRequired();
            builder.Property(e => e.ProdutoId).IsRequired();

            builder.HasOne(x => x.Local)
                .WithMany(p => p.LocalProdutos)
                .HasForeignKey(x => x.LocalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Local_Produto");

            builder.HasOne(x => x.Produto)
                .WithMany(p => p.LocalProdutos)
                .HasForeignKey(x => x.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produto_Local");

            builder.ToTable("Local");
        }
    }
}