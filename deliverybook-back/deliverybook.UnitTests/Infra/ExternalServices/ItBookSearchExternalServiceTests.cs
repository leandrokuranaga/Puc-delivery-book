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
    public class ItBookSearchExternalServiceTests
    {
        public IMapper _mapper { get; }
        private readonly ServicosUrl _apiUrls;
        public Mock<IExternalService> _externalService;

        public ItBookSearchExternalServiceTests()
        {
            _mapper = AutoMapperCreatorTests.CriarMapeamentos();
            _apiUrls = ServicosUrlMock.GerarServicosUrlMock(new string[] { "search" });
            _externalService = new Mock<IExternalService>();
        }

        //[Fact]
        public async Task Devera_retornar_livros_integracao()
        {
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseSearchMockP1);

            var service = new ItBookSearchExternalService(_mapper, _apiUrls, _externalService.Object);
            var parametro = "Handbook";
            int pagina = 6;
            var response = await service.Executar(parametro, pagina);

            response.Should().NotBeNull();
        }

        [Fact]
        public async Task Devera_retornar_livros_sem_pag()
        {
            //Arrange
            var esperado = PaginacaoFaker.GerarPaginacaoSearchEstaticoP1.Generate();
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseSearchMockP1);
            var parametro = "Handbook";
            int pagina = 0;

            //Act
            var service = new ItBookSearchExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar(parametro, pagina);

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
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseSearchMockP1);
            var parametro = "Handbook";
            int pagina = 1;

            //Act
            var service = new ItBookSearchExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar(parametro, pagina);

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
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseSearchMockP6);
            var parametro = "Handbook";
            int pagina = 6;

            //Act
            var service = new ItBookSearchExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar(parametro, pagina);

            //Assert
            response.Should().NotBeNull();
            response.Pagina.Should().Be(pagina);
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_retorno_vazio()
        {
            //Arrange
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseVazio);
            var parametro = "Teste";
            int pagina = 1;

            //Act
            var service = new ItBookSearchExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar(parametro, pagina);

            //Assert
            response.Should().BeNull();
        }
    }
}