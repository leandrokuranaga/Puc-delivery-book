using Bogus;
using deliverybook.API.ViewModel;

namespace deliverybook.UnitTests.Comum.Faker.Api.ViewModel
{
    public static class AudiosViewModelFaker
    {
        public static Faker<AudiosViewModel> GerarAudiosPag1 { get; } =
          new Faker<AudiosViewModel>()
            .RuleFor(p => p.Requisicao, f => "https://api.spotify.com/v1/search?query=Livros&type=show&market=BR&offset=0&limit=10")
            .RuleFor(p => p.Itens, f => PodcastsViewModelFaker.PodcastSearchEstaticaP1())
            .RuleFor(p => p.Paginacao, PaginationViewModelFaker.GerarPaginationPag1.Generate());

        public static Faker<AudiosViewModel> GerarAudiosPag2 { get; } =
           new Faker<AudiosViewModel>()
             .RuleFor(p => p.Requisicao, f => "https://api.spotify.com/v1/search?query=Livros&type=show&market=BR&offset=10&limit=10")
             .RuleFor(p => p.Itens, f => PodcastsViewModelFaker.PodcastSearchEstaticaP2())
             .RuleFor(p => p.Paginacao, PaginationViewModelFaker.GerarPaginationPag2.Generate());
    }
}