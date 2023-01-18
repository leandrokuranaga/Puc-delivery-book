using Bogus;
using deliverybook.API.ViewModel;

namespace deliverybook.UnitTests.Comum.Faker.Api.ViewModel
{
    public static class PaginacaoViewModelFaker
    {
        public static Faker<PaginacaoViewModel> GerarPaginacaoEstatico { get; } =
          new Faker<PaginacaoViewModel>()
            .RuleFor(p => p.Total, f => 20)
            .RuleFor(p => p.Livros, LivroViewModelFaker.GerarLivroListaEstatica());

        public static Faker<PaginacaoViewModel> GerarPaginacaoVMEstaticoP1 { get; } =
         new Faker<PaginacaoViewModel>()
           .RuleFor(p => p.Total, f => 63)
           .RuleFor(p => p.Pagina, f => 1)
           .RuleFor(p => p.Livros, LivroViewModelFaker.GerarLivroListaEstaticaP1());

        public static Faker<PaginacaoViewModel> GerarPaginacaoVMEstaticoP6 { get; } =
          new Faker<PaginacaoViewModel>()
            .RuleFor(p => p.Total, f => 63)
            .RuleFor(p => p.Pagina, f => 6)
            .RuleFor(p => p.Livros, LivroViewModelFaker.GerarLivroListaEstaticaP6());
    }
}