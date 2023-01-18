using deliverybook.Domain.Model.ItBook;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface IItBookSearchExternalService
    {
        Task<Paginacao> Executar(string parametro, int pagina);
    }
}