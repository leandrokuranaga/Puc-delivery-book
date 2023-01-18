using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Spotify;
using deliverybook.Domain.Services;
using deliverybook.UnitTests.Comum.Faker.Domain.Model.Spotify;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace deliverybook.UnitTests.Domain.Services
{
    public class SpotifySearchServiceTests
    {
        public Mock<ISpotifySearchExternalService> _externalService;

        public SpotifySearchServiceTests()
        {
            _externalService = new Mock<ISpotifySearchExternalService>();
        }

        [Fact]
        public async Task Devera_retornar_livro_selecionado()
        {
            //Arrange
            _externalService.Setup(x => x.Executar(It.IsAny<int>()))
                           .ReturnsAsync(AudiosFaker.GerarAudiosPag1.Generate());

            var esperado = AudiosFaker.GerarAudiosPag1.Generate();
            var pagina = 1;

            //Act
            var service = new SpotifySearchService(_externalService.Object);
            var response = await service.Buscar(pagina);

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_nulo()
        {
            //Arrange
            _externalService.Setup(x => x.Executar(It.IsAny<int>()))
                           .ReturnsAsync(null as Audios);
            var pagina = 1;

            //Act
            var service = new SpotifySearchService(_externalService.Object);
            var response = await service.Buscar(pagina);

            //Assert
            response.Should().BeNull();
        }
    }
}