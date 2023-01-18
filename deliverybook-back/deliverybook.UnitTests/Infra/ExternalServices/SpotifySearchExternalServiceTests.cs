using AutoMapper;
using deliverybook.Domain.Model;
using deliverybook.Domain.Model.Spotify.Auth;
using deliverybook.Infra.ExternalServices;
using deliverybook.Infra.Interfaces;
using deliverybook.UnitTests.Comum;
using deliverybook.UnitTests.Comum.Faker.Domain.Model.Spotify;
using deliverybook.UnitTests.Comum.Faker.Domain.Model.Spotify.Auth;
using deliverybook.UnitTests.Comum.Faker.Infra.ExternalServices;
using FluentAssertions;
using Moq;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace deliverybook.UnitTests.Infra.ExternalServices
{
    public class SpotifySearchExternalServiceTests
    {
        public IMapper _mapper { get; }
        private readonly ServicosUrl _apiUrls;
        private readonly ClientCredentials _credentials;
        public Mock<IExternalService> _externalService;

        public SpotifySearchExternalServiceTests()
        {
            _mapper = AutoMapperCreatorTests.CriarMapeamentos();
            _credentials = ClientCredentialsMock.GerarCredenciaisMock();

            _apiUrls = ServicosUrlMock.GerarServicosUrlMock(new string[] { "token",
                                                                           "podcast" });

            _externalService = new Mock<IExternalService>();
            _externalService.Setup(x => x.ExecutarPostAsync(It.IsAny<Uri>(), It.IsAny<AuthenticationHeaderValue>()))
                          .ReturnsAsync(ExternalServiceResponse.PostResponseToken);
        }

        [Fact]
        public async Task Devera_retornar_podcasts_sem_pag()
        {
            //Arrange
            var esperado = AudiosFaker.GerarAudiosPag1.Generate();

            _externalService.Setup(x => x.ExecutarAuthGetAsync(It.IsAny<Uri>(), It.IsAny<AuthenticationHeaderValue>()))
                           .ReturnsAsync(ExternalServiceResponse.GetResponseSearchQueryLivroMock);
            int pagina = 0;

            //Act
            var service = new SpotifySearchExternalService(_mapper, _apiUrls, _credentials, _externalService.Object);
            var response = await service.Executar(pagina);

            //Assert
            response.Should().NotBeNull();
            response.Paginacao.Atual.Should().Be(1);
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_podcasts_pag_1()
        {
            //Arrange
            var esperado = AudiosFaker.GerarAudiosPag1.Generate();

            _externalService.Setup(x => x.ExecutarAuthGetAsync(It.IsAny<Uri>(), It.IsAny<AuthenticationHeaderValue>()))
                           .ReturnsAsync(ExternalServiceResponse.GetResponseSearchQueryLivroMock);
            int pagina = 1;

            //Act
            var service = new SpotifySearchExternalService(_mapper, _apiUrls, _credentials, _externalService.Object);
            var response = await service.Executar(pagina);

            //Assert
            response.Should().NotBeNull();
            response.Paginacao.Atual.Should().Be(pagina);
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_podcasts_pag_2()
        {
            //Arrange
            var esperado = AudiosFaker.GerarAudiosPag2.Generate();

            _externalService.Setup(x => x.ExecutarAuthGetAsync(It.IsAny<Uri>(), It.IsAny<AuthenticationHeaderValue>()))
                           .ReturnsAsync(ExternalServiceResponse.GetResponseSearchQueryLivroPag2Mock);
            int pagina = 2;

            //Act
            var service = new SpotifySearchExternalService(_mapper, _apiUrls, _credentials, _externalService.Object);
            var response = await service.Executar(pagina);

            //Assert
            response.Should().NotBeNull();
            response.Paginacao.Atual.Should().Be(pagina);
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_retorno_vazio()
        {
            //Arrange
            _externalService.Setup(x => x.ExecutarAuthGetAsync(It.IsAny<Uri>(), It.IsAny<AuthenticationHeaderValue>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseVazio);
            int pagina = 1;

            //Act
            var service = new SpotifySearchExternalService(_mapper, _apiUrls, _credentials, _externalService.Object);
            var response = await service.Executar(pagina);

            //Assert
            response.Should().BeNull();
        }
    }
}