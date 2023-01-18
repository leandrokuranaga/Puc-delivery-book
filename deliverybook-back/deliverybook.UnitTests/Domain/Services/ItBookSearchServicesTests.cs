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
    public class ItBookSearchServicesTests
    {
        public Mock<IItBookSearchExternalService> _externalService;

        public ItBookSearchServicesTests()
        {
            _externalService = new Mock<IItBookSearchExternalService>();
        }

        [Fact]
        public async Task Devera_retornar_livros_sem_pag()
        {
            //Arrange
            var esperado = PaginacaoFaker.GerarPaginacaoSearchEstaticoP1.Generate();
            _externalService.Setup(x => x.Executar(It.IsAny<string>(), It.IsAny<int>()))
                            .ReturnsAsync(esperado);
            var parametro = "Handbook";
            int pagina = 0;

            //Act
            var service = new ItBookSearchServices(_externalService.Object);
            var response = await service.BuscarPorFiltro(parametro, pagina);

            //Assert
            response.Should().NotBeNull();
            response.Pagina.Should().Be(1);
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_livros_pag_1()
        {
            //Arrange
            var esperado = PaginacaoFaker.GerarPaginacaoSearchEstaticoP1.Generate();
            _externalService.Setup(x => x.Executar(It.IsAny<string>(), It.IsAny<int>()))
                           .ReturnsAsync(esperado);
            var parametro = "Handbook";
            int pagina = 1;

            //Act
            var service = new ItBookSearchServices(_externalService.Object);
            var response = await service.BuscarPorFiltro(parametro, pagina);

            //Assert
            response.Should().NotBeNull();
            response.Pagina.Should().Be(pagina);
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_livros_pag_6()
        {
            //Arrange
            var esperado = PaginacaoFaker.GerarPaginacaoSearchEstaticoP6.Generate();
            _externalService.Setup(x => x.Executar(It.IsAny<string>(), It.IsAny<int>()))
                          .ReturnsAsync(esperado);
            var parametro = "Handbook";
            int pagina = 6;

            //Act
            var service = new ItBookSearchServices(_externalService.Object);
            var response = await service.BuscarPorFiltro(parametro, pagina);

            //Assert
            response.Should().NotBeNull();
            response.Pagina.Should().Be(pagina);
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_erro()
        {
            //Arrange
            var esperado = PaginacaoFaker.GerarPaginacaoErro.Generate();
            _externalService.Setup(x => x.Executar(It.IsAny<string>(), It.IsAny<int>()))
                            .ReturnsAsync(esperado);
            var parametro = "Handbook";
            int pagina = 0;

            //Act
            var service = new ItBookSearchServices(_externalService.Object);
            var response = await service.BuscarPorFiltro(parametro, pagina);

            //Assert
            response.Should().BeNull();
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_nulo()
        {
            //Arrange
            _externalService.Setup(x => x.Executar(It.IsAny<string>(), It.IsAny<int>()))
                             .ReturnsAsync(null as Paginacao);
            var parametro = "Handbook";
            int pagina = 0;

            //Act
            var service = new ItBookSearchServices(_externalService.Object);
            var response = await service.BuscarPorFiltro(parametro, pagina);

            //Assert
            response.Should().BeNull();
        }
    }
}