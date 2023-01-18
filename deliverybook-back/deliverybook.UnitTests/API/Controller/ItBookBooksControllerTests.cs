using AutoMapper;
using deliverybook.API.Controllers;
using deliverybook.API.ViewModel;
using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.ItBook;
using deliverybook.UnitTests.Comum;
using deliverybook.UnitTests.Comum.Faker.Api.ViewModel;
using deliverybook.UnitTests.Comum.Faker.Domain.Model.ItBook;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace deliverybook.UnitTests.API.Controller
{
    public class ItBookBooksControllerTests
    {
        private readonly IMapper _mapper;
        public Mock<IItBookNewServices> _newServices;
        public Mock<IItBookBooksServices> _booksServices;
        public Mock<IItBookSearchServices> _searchServices;
        public Mock<IRentableServices> _rentableServices;

        public ItBookBooksControllerTests()
        {
            _mapper = AutoMapperCreatorTests.CriarMapeamentos();
            _newServices = new Mock<IItBookNewServices>();
            _booksServices = new Mock<IItBookBooksServices>();
            _searchServices = new Mock<IItBookSearchServices>();
            _rentableServices = new Mock<IRentableServices>();
        }

        [Fact]
        public async Task Devera_retornar_livro_selecionado()
        {
            //Arrange
            var esperado = DetalhesViewModelFaker.GerarDetalhesEstatico.Generate();
            _booksServices.Setup(x => x.BuscarPorId(It.IsAny<string>()))
                            .ReturnsAsync(DetalhesFaker.GerarDetalhesEstatico.Generate());
            var id = "9781484211830";

            //Act
            var controller = new LivrosController(_mapper, _newServices.Object, _booksServices.Object, _searchServices.Object, _rentableServices.Object);
            var response = await controller.Get(id);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as DetalhesViewModel;
            atual.Should().NotBeNull();
            atual.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_livro_com_capitulos_selecionado()
        {
            //Arrange
            var esperado = DetalhesViewModelFaker.GerarDetalhesComPdfEstatico.Generate();
            _booksServices.Setup(x => x.BuscarPorId(It.IsAny<string>()))
                            .ReturnsAsync(DetalhesFaker.GerarDetalhesComPdfEstatico.Generate());
            var id = "9781617291609";

            //Act
            var controller = new LivrosController(_mapper, _newServices.Object, _booksServices.Object, _searchServices.Object, _rentableServices.Object);
            var response = await controller.Get(id);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as DetalhesViewModel;
            atual.Should().NotBeNull();
            atual.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_nulo()
        {
            //Arrange
            _booksServices.Setup(x => x.BuscarPorId(It.IsAny<string>()))
                            .ReturnsAsync(null as Detalhes);
            var id = "9781617291609";

            //Act
            var controller = new LivrosController(_mapper, _newServices.Object, _booksServices.Object, _searchServices.Object, _rentableServices.Object);
            var response = await controller.Get(id);

            //Assert
            response.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}