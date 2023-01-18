using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.ItBook;
using System.Threading.Tasks;

namespace deliverybook.Domain.Services
{
    public class ItBookNewServices : IItBookNewServices
    {
        private readonly IItBookNewExternalService _newExternalService;

        public ItBookNewServices(IItBookNewExternalService newExternalService)
        {
            _newExternalService = newExternalService;
        }

        public async Task<Paginacao> Buscar()
        {
            var response = await _newExternalService.Executar();

            if (response == null || response.IsValid())
                return null;

            return response;
        }
    }
}