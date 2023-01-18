using deliverybook.Domain.Model.Aluguel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace deliverybook.Infra.Context.Mappings
{
    public class AluguelTypeConfigurations : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.DataInicio).HasColumnType("datetime").IsRequired();
            builder.Property(e => e.DataFim).HasColumnType("datetime").IsRequired();
            builder.Property(e => e.Isbn13).HasColumnType("varchar(50)");
            builder.Property(e => e.UserId).HasColumnType("varchar(500)");
            builder.Property(e => e.LivroDigital).HasColumnType("varchar(max)");
        }
    }
}