using Bogus;
using deliverybook.Domain.Model;

namespace deliverybook.UnitTests.Comum.Faker.Domain.Model
{
    public static class PaginationFaker
    {
        public static Faker<Pagination> GerarPaginationPag1 { get; } =
           new Faker<Pagination>()
             .RuleFor(p => p.Atual, f => 1)
             .RuleFor(p => p.Limite, f => 10)
             .RuleFor(p => p.Offset, f => 0)
             .RuleFor(p => p.Total, f => 5587)
             .RuleFor(p => p.Anterior, f => null)
             .RuleFor(p => p.Proximo, f => "https://api.spotify.com/v1/search?query=Livros&type=show&market=BR&offset=10&limit=10");

        public static Faker<Pagination> GerarPaginationPag2 { get; } =
           new Faker<Pagination>()
             .RuleFor(p => p.Atual, f => 2)
             .RuleFor(p => p.Limite, f => 10)
             .RuleFor(p => p.Offset, f => 10)
             .RuleFor(p => p.Total, f => 5600)
             .RuleFor(p => p.Anterior, f => "https://api.spotify.com/v1/search?query=Livros&type=show&market=BR&offset=0&limit=10")
             .RuleFor(p => p.Proximo, f => "https://api.spotify.com/v1/search?query=Livros&type=show&market=BR&offset=20&limit=10");
    }
}