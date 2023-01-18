using AutoMapper;
using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model;
using deliverybook.Domain.Model.Spotify;
using deliverybook.Domain.Model.Spotify.Auth;
using deliverybook.Infra.Entities.Spotify;
using deliverybook.Infra.Entities.Spotify.Auth;
using deliverybook.Infra.Extensions;
using deliverybook.Infra.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace deliverybook.Infra.ExternalServices
{
    public class SpotifySearchExternalService : ISpotifySearchExternalService
    {
        private readonly IMapper _mapper;
        private readonly IExternalService _externalService;
        private readonly ClientCredentials _credentials;
        private readonly static string _apiToken = "token";
        private readonly static string _apiPodcast = "podcast";
        private readonly string _linkToken;
        private readonly string _linkPodcast;

        public SpotifySearchExternalService(IMapper mapper, ServicosUrl servicosUrl, ClientCredentials credentials, IExternalService externalService)
        {
            _mapper = mapper;
            _linkToken = servicosUrl.ListaUrls.Find(x => x.NomeApi.Equals(_apiToken)).Link;
            _linkPodcast = servicosUrl.ListaUrls.Find(x => x.NomeApi.Equals(_apiPodcast)).Link;
            _credentials = credentials;
            _externalService = externalService;
        }

        public async Task<Audios> Executar(int pagina)
        {
            var token = await BuscarToken();
            var response = await _externalService.ExecutarAuthGetAsync(_linkPodcast.GerarPodcastUrl(pagina), token);

            if (response == null)
                return null;

            var podcasts = JsonConvert.DeserializeObject<Metadata>(response);

            return _mapper.Map<Audios>(podcasts);
        }

        private async Task<AuthenticationHeaderValue> BuscarToken()
        {
            var auth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(_credentials.ToString())));
            var response = await _externalService.ExecutarPostAsync(new Uri(_linkToken), auth);

            var accessToken = JsonConvert.DeserializeObject<AccessToken>(response);

            return new AuthenticationHeaderValue(accessToken.Token_type, accessToken.Access_token);
        }
    }
}