using deliverybook.Domain.Model.Localizacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace deliverybook.Infra.Context.Mappings
{
    public class LocalTypeConfigurations : IEntityTypeConfiguration<Local>
    {
        public void Configure(EntityTypeBuilder<Local> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Descricao).HasColumnType("varchar(max)").IsRequired();
            builder.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");
            builder.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
        }
    }
}