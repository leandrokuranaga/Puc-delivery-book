using deliverybook.Domain.Model.ItBook;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface IItBookSearchServices
    {
        Task<Paginacao> BuscarPorFiltro(string parametro, int pagina);
    }
}