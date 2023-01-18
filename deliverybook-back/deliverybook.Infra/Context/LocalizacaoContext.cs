using deliverybook.Domain.Model.Aluguel;
using deliverybook.Domain.Model.Localizacao;
using deliverybook.Infra.Context.Mappings;
using Microsoft.EntityFrameworkCore;

namespace deliverybook.Infra.Context
{
    public class LocalizacaoContext : DbContext
    {
        public DbSet<Local> Locais { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<LocalProduto> LocalProdutos { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        

        public LocalizacaoContext(DbContextOptions<LocalizacaoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //confirmação de configuraão para utilizar com In Memory Database
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase(databaseName: $"LocalizacaoContext");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocalProdutoTypeConfigurations());
            modelBuilder.ApplyConfiguration(new LocalTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ProdutoTypeConfigurations());
            modelBuilder.ApplyConfiguration(new AluguelTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ReservaTypeConfigurations());
        }
    }
}