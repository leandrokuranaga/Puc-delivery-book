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
    public class ItBookNewServicesTests
    {
        public Mock<IItBookNewExternalService> _externalService;

        public ItBookNewServicesTests()
        {
            _externalService = new Mock<IItBookNewExternalService>();
        }

        [Fact]
        public async Task Devera_retornar_livros()
        {
            //Arrange
            var esperado = PaginacaoFaker.GerarPaginacaoEstatico.Generate();
            _externalService.Setup(x => x.Executar())
                            .ReturnsAsync(esperado);

            //Act
            var service = new ItBookNewServices(_externalService.Object);
            var response = await service.Buscar();

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_erro()
        {
            //Arrange
            var esperado = PaginacaoFaker.GerarPaginacaoErro.Generate();
            _externalService.Setup(x => x.Executar())
                            .ReturnsAsync(esperado);

            //Act
            var service = new ItBookNewServices(_externalService.Object);
            var response = await service.Buscar();

            //Assert
            response.Should().BeNull();
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_nulo()
        {
            //Arrange
            _externalService.Setup(x => x.Executar())
                             .ReturnsAsync(null as Paginacao);

            //Act
            var service = new ItBookNewServices(_externalService.Object);
            var response = await service.Buscar();

            //Assert
            response.Should().BeNull();
        }
    }
}