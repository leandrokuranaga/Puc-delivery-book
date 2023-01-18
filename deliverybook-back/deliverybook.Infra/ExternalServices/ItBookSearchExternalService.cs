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
    public class ItBookSearchExternalService : IItBookSearchExternalService
    {
        private readonly IMapper _mapper;
        private readonly IExternalService _externalService;
        private readonly static string _api = "search";
        private readonly string _link;

        public ItBookSearchExternalService(IMapper mapper, ServicosUrl servicosUrl, IExternalService externalService)
        {
            _mapper = mapper;
            _link = servicosUrl.ListaUrls.Find(x => x.NomeApi.Equals(_api)).Link;
            _externalService = externalService;
        }

        public async Task<Paginacao> Executar(string parametro, int pagina)
        {
            var response = await _externalService.ExecutarGetAsync(_link.GerarSearchUrl(parametro, pagina));

            if (response == null)
                return null;

            var detalhes = JsonConvert.DeserializeObject<PageDAO>(response);

            return _mapper.Map<Paginacao>(detalhes);
        }
    }
}