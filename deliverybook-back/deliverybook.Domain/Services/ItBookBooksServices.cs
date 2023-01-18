using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.ItBook;
using System.Threading.Tasks;

namespace deliverybook.Domain.Services
{
    public class ItBookBooksServices : IItBookBooksServices
    {
        private readonly IItBookBooksExternalService _booksExternalService;

        public ItBookBooksServices(IItBookBooksExternalService booksExternalService)
        {
            _booksExternalService = booksExternalService;
        }

        public async Task<Detalhes> BuscarPorId(string id)
        {
            var response = await _booksExternalService.Executar(id);

            if (response == null || response.IsValid())
                return null;

            response.IsRentable();
            return response;
        }
    }
}