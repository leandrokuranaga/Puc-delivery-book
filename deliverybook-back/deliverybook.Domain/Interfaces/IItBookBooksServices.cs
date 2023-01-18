using deliverybook.Domain.Model.ItBook;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface IItBookBooksServices
    {
        Task<Detalhes> BuscarPorId(string id);
    }
}