using deliverybook.Domain.Model.Spotify;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface ISpotifySearchService
    {
        Task<Audios> Buscar(int pagina);
    }
}