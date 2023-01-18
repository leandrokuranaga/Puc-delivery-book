using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Spotify;
using System.Threading.Tasks;

namespace deliverybook.Domain.Services
{
    public class SpotifySearchService : ISpotifySearchService
    {
        private readonly ISpotifySearchExternalService _searchExternalService;

        public SpotifySearchService(ISpotifySearchExternalService searchExternalService)
        {
            _searchExternalService = searchExternalService;
        }

        public async Task<Audios> Buscar(int pagina)
        {
            return await _searchExternalService.Executar(pagina);
        }
    }
}