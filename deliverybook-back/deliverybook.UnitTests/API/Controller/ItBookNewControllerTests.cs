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
    public class ItBookNewControllerTests
    {
        private readonly IMapper _mapper;
        public Mock<IItBookNewServices> _newServices;
        public Mock<IItBookBooksServices> _booksServices;
        public Mock<IItBookSearchServices> _searchServices;
        public Mock<IRentableServices> _rentableServices;

        public ItBookNewControllerTests()
        {
            _mapper = AutoMapperCreatorTests.CriarMapeamentos();
            _newServices = new Mock<IItBookNewServices>();
            _booksServices = new Mock<IItBookBooksServices>();
            _searchServices = new Mock<IItBookSearchServices>();
            _rentableServices = new Mock<IRentableServices>();
        }

        [Fact]
        public async Task Devera_retornar_livros()
        {
            //Arrange
            var esperado = PaginacaoViewModelFaker.GerarPaginacaoEstatico.Generate();
            _newServices.Setup(x => x.Buscar())
                            .ReturnsAsync(PaginacaoFaker.GerarPaginacaoEstatico.Generate());

            //Act
            var controller = new LivrosController(_mapper, _newServices.Object, _booksServices.Object, _searchServices.Object,  _rentableServices.Object);
            var response = await controller.Get();

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as PaginacaoViewModel;
            atual.Should().NotBeNull();
            atual.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_nulo()
        {
            //Arrange
            _newServices.Setup(x => x.Buscar())
                            .ReturnsAsync(null as Paginacao);

            //Act
            var controller = new LivrosController(_mapper, _newServices.Object, _booksServices.Object, _searchServices.Object,  _rentableServices.Object);
            var response = await controller.Get();

            //Assert
            response.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}