using Bogus;
using deliverybook.Domain.Model.ItBook;
using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Domain.Model.ItBook
{
    public static class PaginacaoFaker
    {
        public static Faker<Paginacao> GerarPaginacaoEstatico { get; } =
           new Faker<Paginacao>()
             .RuleFor(p => p.Erro, f => "0")
             .RuleFor(p => p.Total, f => 20)
             .RuleFor(p => p.Livros, LivroFaker.GerarLivroListaEstatica());

        public static Faker<Paginacao> GerarPaginacaoSearchEstaticoP1 { get; } =
           new Faker<Paginacao>()
             .RuleFor(p => p.Erro, f => "0")
             .RuleFor(p => p.Total, f => 63)
             .RuleFor(p => p.Pagina, f => 1)
             .RuleFor(p => p.Livros, LivroFaker.GerarLivroListaSearchEstaticaP1());

        public static Faker<Paginacao> GerarPaginacaoSearchEstaticoP6 { get; } =
           new Faker<Paginacao>()
             .RuleFor(p => p.Erro, f => "0")
             .RuleFor(p => p.Total, f => 63)
             .RuleFor(p => p.Pagina, f => 6)
             .RuleFor(p => p.Livros, LivroFaker.GerarLivroListaSearchEstaticaP6());

        public static Faker<Paginacao> GerarPaginacaoErro { get; } =
           new Faker<Paginacao>()
             .RuleFor(p => p.Erro, f => "1")
             .RuleFor(p => p.Total, f => 0)
             .RuleFor(p => p.Livros, new List<Livro>());
    }
}