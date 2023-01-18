using deliverybook.Domain.Model.Spotify;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface ISpotifySearchExternalService
    {
        Task<Audios> Executar(int pagina);
    }
}