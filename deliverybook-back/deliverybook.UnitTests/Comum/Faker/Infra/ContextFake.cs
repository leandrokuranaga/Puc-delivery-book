using deliverybook.API.Configurations;
using deliverybook.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace deliverybook.UnitTests.Comum.Faker.Infra
{
    public class ContextFake
    {
        public DbContextOptions<LocalizacaoContext> Options { get; }

        public ContextFake(string nomeTeste)
        {
            var dbContext = new DbContextOptionsBuilder<LocalizacaoContext>();
            Options = dbContext
                      .UseInMemoryDatabase(databaseName: $"LocalizacaoContext_{nomeTeste}")
                      .Options;

            InitializeDatabase.DataGenerator(dbContext);
        }
    }
}