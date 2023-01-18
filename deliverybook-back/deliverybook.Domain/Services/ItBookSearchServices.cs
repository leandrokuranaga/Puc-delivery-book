using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.ItBook;
using System.Threading.Tasks;

namespace deliverybook.Domain.Services
{
    public class ItBookSearchServices : IItBookSearchServices
    {
        private readonly IItBookSearchExternalService _searchExternalService;

        public ItBookSearchServices(IItBookSearchExternalService searchExternalService)
        {
            _searchExternalService = searchExternalService;
        }

        public async Task<Paginacao> BuscarPorFiltro(string parametro, int pagina)
        {
            var response = await _searchExternalService.Executar(parametro, pagina);

            if (response == null || response.IsValid())
                return null;

            return response;
        }
    }
}