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
    public class ItBookSearchControllerTests
    {
        private readonly IMapper _mapper;
        public Mock<IItBookNewServices> _newServices;
        public Mock<IItBookBooksServices> _booksServices;
        public Mock<IItBookSearchServices> _searchServices;
        public Mock<IRentableServices> _rentableServices;

        public ItBookSearchControllerTests()
        {
            _mapper = AutoMapperCreatorTests.CriarMapeamentos();
            _newServices = new Mock<IItBookNewServices>();
            _booksServices = new Mock<IItBookBooksServices>();
            _searchServices = new Mock<IItBookSearchServices>();
            _rentableServices = new Mock<IRentableServices>();
        }

        [Fact]
        public async Task Devera_retornar_livros_sem_pag()
        {
            //Arrange
            var esperado = PaginacaoViewModelFaker.GerarPaginacaoVMEstaticoP1.Generate();
            _searchServices.Setup(x => x.BuscarPorFiltro(It.IsAny<string>(), It.IsAny<int>()))
                            .ReturnsAsync(PaginacaoFaker.GerarPaginacaoSearchEstaticoP1.Generate());
            var parametro = "Handbook";
            int pagina = 0;

            //Act
            var controller = new LivrosController(_mapper, _newServices.Object, _booksServices.Object, _searchServices.Object, _rentableServices.Object);
            var response = await controller.GetFiltro(parametro, pagina);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as PaginacaoViewModel;
            atual.Should().NotBeNull();
            atual.Pagina.Should().Be(1);
            atual.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_livros_pag_1()
        {
            //Arrange
            var esperado = PaginacaoViewModelFaker.GerarPaginacaoVMEstaticoP1.Generate();
            _searchServices.Setup(x => x.BuscarPorFiltro(It.IsAny<string>(), It.IsAny<int>()))
                            .ReturnsAsync(PaginacaoFaker.GerarPaginacaoSearchEstaticoP1.Generate());
            var parametro = "Handbook";
            int pagina = 1;

            //Act
            var controller = new LivrosController(_mapper, _newServices.Object, _booksServices.Object, _searchServices.Object, _rentableServices.Object);
            var response = await controller.GetFiltro(parametro, pagina);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as PaginacaoViewModel;
            atual.Should().NotBeNull();
            atual.Pagina.Should().Be(pagina);
            atual.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_livros_pag_6()
        {
            //Arrange
            var esperado = PaginacaoViewModelFaker.GerarPaginacaoVMEstaticoP6.Generate();
            _searchServices.Setup(x => x.BuscarPorFiltro(It.IsAny<string>(), It.IsAny<int>()))
                            .ReturnsAsync(PaginacaoFaker.GerarPaginacaoSearchEstaticoP6.Generate());
            var parametro = "Handbook";
            int pagina = 6;

            //Act
            var controller = new LivrosController(_mapper, _newServices.Object, _booksServices.Object, _searchServices.Object, _rentableServices.Object);
            var response = await controller.GetFiltro(parametro, pagina);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as PaginacaoViewModel;
            atual.Should().NotBeNull();
            atual.Pagina.Should().Be(pagina);
            atual.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_nulo()
        {
            //Arrange
            _searchServices.Setup(x => x.BuscarPorFiltro(It.IsAny<string>(), It.IsAny<int>()))
                            .ReturnsAsync(null as Paginacao);
            var parametro = "Teste";
            int pagina = 1;

            //Act
            var controller = new LivrosController(_mapper, _newServices.Object, _booksServices.Object, _searchServices.Object, _rentableServices.Object);
            var response = await controller.GetFiltro(parametro, pagina);

            //Assert
            response.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}