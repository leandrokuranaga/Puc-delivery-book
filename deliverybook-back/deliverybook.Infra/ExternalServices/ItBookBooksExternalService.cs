using AutoMapper;
using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model;
using deliverybook.Domain.Model.ItBook;
using deliverybook.Infra.Entities.ItBook;
using deliverybook.Infra.Extensions;
using deliverybook.Infra.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace deliverybook.Infra.ExternalServices
{
    public class ItBookBooksExternalService : IItBookBooksExternalService
    {
        private readonly IMapper _mapper;
        private readonly IExternalService _externalService;
        private readonly static string _api = "books";
        private readonly string _link;

        public ItBookBooksExternalService(IMapper mapper, ServicosUrl servicosUrl, IExternalService externalService)
        {
            _mapper = mapper;
            _link = servicosUrl.ListaUrls.Find(x => x.NomeApi.Equals(_api)).Link;
            _externalService = externalService;
        }

        public async Task<Detalhes> Executar(string isbn)
        {
            var response = await _externalService.ExecutarGetAsync(_link.GerarBooksUrl(isbn));

            if (response == null)
                return null;

            var detalhes = JsonConvert.DeserializeObject<DetailsDAO>(response);

            return _mapper.Map<Detalhes>(detalhes);
        }
    }
}