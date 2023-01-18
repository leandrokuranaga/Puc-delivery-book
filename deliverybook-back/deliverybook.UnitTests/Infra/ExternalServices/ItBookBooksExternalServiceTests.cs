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
    public class ItBookBooksExternalServiceTests
    {
        public IMapper _mapper { get; }
        private readonly ServicosUrl _apiUrls;
        public Mock<IExternalService> _externalService;

        public ItBookBooksExternalServiceTests()
        {
            _mapper = AutoMapperCreatorTests.CriarMapeamentos();
            _externalService = new Mock<IExternalService>();
            _apiUrls = ServicosUrlMock.GerarServicosUrlMock(new string[] { "books" });
        }

        //[Fact]
        public async Task Devera_retornar_livro_selecionado_integracao()
        {
            var isbn = "9781484211830";
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                           .ReturnsAsync(ExternalServiceResponse.GetResponseBooksMock);

            var service = new ItBookBooksExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar(isbn);

            response.Should().NotBeNull();
        }

        [Fact]
        public async Task Devera_retornar_livro_selecionado()
        {
            //Arrange
            var esperado = DetalhesFaker.GerarDetalhesEstatico.Generate();
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseBooksMock);
            var isbn = "9781484211830";

            //Act
            var service = new ItBookBooksExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar(isbn);

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_livro_com_capitulos_selecionado()
        {
            //Arrange
            var esperado = DetalhesFaker.GerarDetalhesComPdfEstatico.Generate();
            _externalService.Setup(x => x.ExecutarGetAsync(It.IsAny<Uri>()))
                            .ReturnsAsync(ExternalServiceResponse.GetResponseBooksMockPdf);
            var isbn = "9781617291609";

            //Act
            var service = new ItBookBooksExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar(isbn);

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
            var isbn = "9781617291609";

            //Act
            var service = new ItBookBooksExternalService(_mapper, _apiUrls, _externalService.Object);
            var response = await service.Executar(isbn);

            //Assert
            response.Should().BeNull();
        }
    }
}