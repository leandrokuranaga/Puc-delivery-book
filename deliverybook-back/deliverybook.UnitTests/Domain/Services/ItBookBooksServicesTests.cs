using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.ItBook;
using deliverybook.Domain.Services;
using deliverybook.UnitTests.Comum.Faker.Domain.Model.ItBook;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace deliverybook.UnitTests.Domain.Services
{
    public class ItBookBooksServicesTests
    {
        public Mock<IItBookBooksExternalService> _externalService;

        public ItBookBooksServicesTests()
        {
            _externalService = new Mock<IItBookBooksExternalService>();
        }

        [Fact]
        public async Task Devera_retornar_livro_selecionado()
        {
            //Arrange
            var esperado = DetalhesFaker.GerarDetalhesEstatico.Generate();
            _externalService.Setup(x => x.Executar(It.IsAny<string>()))
                            .ReturnsAsync(esperado);
            var isbn = "9781484211830";

            //Act
            var service = new ItBookBooksServices(_externalService.Object);
            var response = await service.BuscarPorId(isbn);

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_livro_com_capitulos_selecionado()
        {
            //Arrange
            var esperado = DetalhesFaker.GerarDetalhesComPdfEstatico.Generate();
            _externalService.Setup(x => x.Executar(It.IsAny<string>()))
                           .ReturnsAsync(esperado);
            var isbn = "9781617291609";

            //Act
            var service = new ItBookBooksServices(_externalService.Object);
            var response = await service.BuscarPorId(isbn);

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_erro()
        {
            //Arrange
            var esperado = DetalhesFaker.GerarDetalhesErro.Generate();
            _externalService.Setup(x => x.Executar(It.IsAny<string>()))
                           .ReturnsAsync(esperado);
            var isbn = "9781617291609";

            //Act
            var service = new ItBookBooksServices(_externalService.Object);
            var response = await service.BuscarPorId(isbn);

            //Assert
            response.Should().BeNull();
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_nulo()
        {
            //Arrange
            _externalService.Setup(x => x.Executar(It.IsAny<string>()))
                           .ReturnsAsync(null as Detalhes);
            var isbn = "9781617291609";

            //Act
            var service = new ItBookBooksServices(_externalService.Object);
            var response = await service.BuscarPorId(isbn);

            //Assert
            response.Should().BeNull();
        }
    }
}