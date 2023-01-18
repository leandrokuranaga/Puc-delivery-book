using AutoMapper;
using deliverybook.Domain.Model;
using deliverybook.Infra.ExternalServices;
using deliverybook.Infra.Interfaces;
using deliverybook.UnitTests.Comum;
using deliverybook.UnitTests.Comum.Faker.Domain.Model.ItBook;
using deliverybook.UnitTests.Comum.Faker.Infra.ExternalServices;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace deliverybook.UnitTests.Infra.ExternalServices
{
    public class ItBookNewExternalServiceTests
    {
        public IMapper _mapper { get; }
        private readonly ServicosUrl _apiUrls;
        public Mock<IExternalService> _externalService;

        public ItBookNewExternalServiceTests()
        {
            _mapper = AutoMapperCreatorTests.CriarMapeamentos();
            _externalService = new Mock<IExternalService>();
            _apiUrls = ServicosUrlMock.GerarServicosUrlMock(new string[] { "new" });
        }

        //[Fact]
        public async Task Devera_retornar_livros_integracao()
        {
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseNewMock);

            var service = new ItBookNewExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar();

            response.Should().NotBeNull();
        }

        [Fact]
        public async Task Devera_retornar_livros()
        {
            //Arrange
            var esperado = PaginacaoFaker.GerarPaginacaoEstatico.Generate();
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseNewMock);

            //Act
            var service = new ItBookNewExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar();

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_retorno_vazio()
        {
            //Arrange
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseVazio);

            //Act
            var service = new ItBookNewExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar();

            //Assert
            response.Should().BeNull();
        }
    }
}