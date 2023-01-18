using AutoMapper;
using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model;
using deliverybook.Domain.Model.ItBook;
using deliverybook.Infra.Entities.ItBook;
using deliverybook.Infra.Interfaces;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace deliverybook.Infra.ExternalServices
{
    public class ItBookNewExternalService : IItBookNewExternalService
    {
        private readonly IMapper _mapper;
        private readonly IExternalService _externalService;
        private readonly static string _api = "new";
        private readonly string _link;

        public ItBookNewExternalService(IMapper mapper, ServicosUrl servicosUrl, IExternalService externalService)
        {
            _mapper = mapper;
            _link = servicosUrl.ListaUrls.Find(x => x.NomeApi.Equals(_api)).Link;
            _externalService = externalService;
        }

        public async Task<Paginacao> Executar()
        {
            var response = await _externalService.ExecutarGetAsync(new Uri(_link));

            if (response == null)
                return null;

            var detalhes = JsonConvert.DeserializeObject<PageDAO>(response);

            return _mapper.Map<Paginacao>(detalhes);
        }
    }
}