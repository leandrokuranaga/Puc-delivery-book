using AutoMapper;
using deliverybook.API.Controllers;
using deliverybook.API.ViewModel;
using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Spotify;
using deliverybook.UnitTests.Comum;
using deliverybook.UnitTests.Comum.Faker.Api.ViewModel;
using deliverybook.UnitTests.Comum.Faker.Domain.Model.Spotify;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace deliverybook.UnitTests.API.Controller
{
    public class SpotifySearchControllerTests
    {
        private readonly IMapper _mapper;
        public Mock<ISpotifySearchService> _searchServices;

        public SpotifySearchControllerTests()
        {
            _mapper = AutoMapperCreatorTests.CriarMapeamentos();
            _searchServices = new Mock<ISpotifySearchService>();
        }

        [Fact]
        public async Task Devera_retornar_audios_sem_pag()
        {
            //Arrange
            var esperado = AudiosViewModelFaker.GerarAudiosPag1.Generate();
            _searchServices.Setup(x => x.Buscar(It.IsAny<int>()))
                            .ReturnsAsync(AudiosFaker.GerarAudiosPag1.Generate());

            //Act
            var controller = new AudiosController(_mapper, _searchServices.Object);
            var response = await controller.Get();

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as AudiosViewModel;
            atual.Should().NotBeNull();
            atual.Paginacao.Atual.Should().Be(1);
            atual.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_audios_pag_1()
        {
            //Arrange
            var esperado = AudiosViewModelFaker.GerarAudiosPag1.Generate();
            _searchServices.Setup(x => x.Buscar(It.IsAny<int>()))
                            .ReturnsAsync(AudiosFaker.GerarAudiosPag1.Generate());
            int pagina = 1;

            //Act
            var controller = new AudiosController(_mapper, _searchServices.Object);
            var response = await controller.Get(pagina);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as AudiosViewModel;
            atual.Should().NotBeNull();
            atual.Paginacao.Atual.Should().Be(pagina);
            atual.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_audios_pag_2()
        {
            //Arrange
            var esperado = AudiosViewModelFaker.GerarAudiosPag2.Generate();
            _searchServices.Setup(x => x.Buscar(It.IsAny<int>()))
                            .ReturnsAsync(AudiosFaker.GerarAudiosPag2.Generate());
            int pagina = 2;

            //Act
            var controller = new AudiosController(_mapper, _searchServices.Object);
            var response = await controller.Get(pagina);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as AudiosViewModel;
            atual.Should().NotBeNull();
            atual.Paginacao.Atual.Should().Be(pagina);
            atual.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_nulo_quando_nulo()
        {
            //Arrange
            _searchServices.Setup(x => x.Buscar(It.IsAny<int>()))
                            .ReturnsAsync(null as Audios);
            int pagina = 1;

            //Act
            var controller = new AudiosController(_mapper, _searchServices.Object);
            var response = await controller.Get(pagina);

            //Assert
            response.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}