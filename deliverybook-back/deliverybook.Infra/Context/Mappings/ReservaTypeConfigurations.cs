using deliverybook.Domain.Model.Localizacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace deliverybook.Infra.Context.Mappings
{
    public class ReservaTypeConfigurations : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.LocalId).IsRequired();
            builder.Property(e => e.ProdutoId).IsRequired();
            builder.Property(e => e.DescricaoLocal).HasColumnType("varchar(max)").IsRequired();
            builder.Property(e => e.Titulo).HasColumnType("varchar(100)");
            builder.Property(e => e.UserId).HasColumnType("varchar(100)");
            builder.Property(e => e.DataReserva).HasColumnType("datetime").IsRequired();
        }
    }
}