using Bogus;
using deliverybook.Domain.Model.Spotify;

namespace deliverybook.UnitTests.Comum.Faker.Domain.Model.Spotify
{
    public static class AudiosFaker
    {
        public static Faker<Audios> GerarAudiosPag1 { get; } =
           new Faker<Audios>()
             .RuleFor(p => p.Requisicao, f => "https://api.spotify.com/v1/search?query=Livros&type=show&market=BR&offset=0&limit=10")
             .RuleFor(p => p.Itens, f => PodcastsFaker.PodcastSearchEstaticaP1())
             .RuleFor(p => p.Paginacao, PaginationFaker.GerarPaginationPag1.Generate());

        public static Faker<Audios> GerarAudiosPag2 { get; } =
           new Faker<Audios>()
             .RuleFor(p => p.Requisicao, f => "https://api.spotify.com/v1/search?query=Livros&type=show&market=BR&offset=10&limit=10")
             .RuleFor(p => p.Itens, f => PodcastsFaker.PodcastSearchEstaticaP2())
             .RuleFor(p => p.Paginacao, PaginationFaker.GerarPaginationPag2.Generate());
    }
}