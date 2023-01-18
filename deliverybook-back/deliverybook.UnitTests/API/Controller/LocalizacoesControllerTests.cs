using AutoMapper;
using deliverybook.API.Controllers;
using deliverybook.API.ViewModel;
using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Localizacao;
using deliverybook.UnitTests.Comum;
using deliverybook.UnitTests.Comum.Faker.Api.ViewModel;
using deliverybook.UnitTests.Comum.Faker.Domain.Model.Localizacao;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace deliverybook.UnitTests.API.Controller
{
    public class LocalizacoesControllerTests
    {
        private readonly IMapper _mapper;
        public Mock<ILocalServices> _localServices;
        public Mock<IProdutoService> _livroServices;
        public Mock<IReservaServices> _reservaServices;
        
        public LocalizacoesControllerTests()
        {
            _mapper = AutoMapperCreatorTests.CriarMapeamentos();
            _localServices = new Mock<ILocalServices>();
            _livroServices = new Mock<IProdutoService>();
            _reservaServices = new Mock<IReservaServices>();
        }

        [Fact]
        public async Task Devera_retornar_todos_locais()
        {
            //Arrange
            var retorno = LocalFaker.GerarLocaisListaEstatica();
            var esperado = LocalizacaoViewModelFaker.GerarLocaisListaEstatica();

            _localServices.Setup(x => x.ObterTodos())
                           .ReturnsAsync(retorno);

            //Act
            var controller = new LocalizacoesController(_mapper, _localServices.Object, _livroServices.Object, _reservaServices.Object);
            var response = await controller.Get();

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as List<LocalizacaoViewModel>;
            atual.Should().NotBeNull();
            atual.Should().BeEquivalentTo(esperado, options => options.Excluding(x => x.LocalLivros));
        }

        //[Fact]
        public async Task Devera_retornar_locais_nulo()
        {
            //Arrange
            _localServices.Setup(x => x.ObterTodos())
                          .ReturnsAsync(null as List<Local>);

            //Act
            var controller = new LocalizacoesController(_mapper, _localServices.Object, _livroServices.Object, _reservaServices.Object);
            var response = await controller.Get();

            //Assert
            response.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Devera_retornar_local_por_id()
        {
            //Arrange
            var retorno = ProdutoFaker.GerarProdutosListaEstatica();
            var esperado = LivroTrocaViewModelFaker.GerarLivroTrocaListaEstatica();
            _livroServices.Setup(x => x.PesquisarPorLocalId(It.IsAny<Guid>()))
                           .ReturnsAsync(retorno);
            var localId = new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5");

            //Act
            var controller = new LocalizacoesController(_mapper, _localServices.Object, _livroServices.Object, _reservaServices.Object);
            var response = await controller.Get(localId);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value as List<LivroTrocaViewModel>;
            atual.Should().NotBeNull();
            atual.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_adicionar_referencia()
        {
            //Arrange
            var esperado = true;
            _localServices.Setup(x => x.Adicionar(It.IsAny<Local>()))
                           .ReturnsAsync(esperado);
            var local = LocalizacaoViewModelFaker.GerarLocaisListaEstatica().FirstOrDefault();

            //Act
            var controller = new LocalizacoesController(_mapper, _localServices.Object, _livroServices.Object, _reservaServices.Object);
            var response = await controller.Post(local);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value;
            atual.Should().NotBeNull();
            atual.Should().Be(esperado);
        }

        [Fact]
        public async Task Devera_editar_referencia()
        {
            //Arrange
            var esperado = true;
            _localServices.Setup(x => x.Atualizar(It.IsAny<Local>()))
                           .ReturnsAsync(esperado);
            var local = LocalizacaoViewModelFaker.GerarLocaisListaEstatica().FirstOrDefault();

            //Act
            var controller = new LocalizacoesController(_mapper, _localServices.Object, _livroServices.Object, _reservaServices.Object);
            var response = await controller.Put(local.Id, local);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value;
            atual.Should().NotBeNull();
            atual.Should().Be(esperado);
        }

        [Fact]
        public async Task Devera_deixar_livro()
        {
            //Arrange
            var esperado = true;
            _livroServices.Setup(x => x.Adicionar(It.IsAny<Produto>()))
                           .ReturnsAsync(esperado);
            var livro = LivroTrocaViewModelFaker.GerarLivroTrocaListaEstatica().FirstOrDefault();

            //Act
            var controller = new LocalizacoesController(_mapper, _localServices.Object, _livroServices.Object, _reservaServices.Object);
            var response = await controller.Post(livro);

            //Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var atual = (response.Result as OkObjectResult).Value;
            atual.Should().NotBeNull();
            atual.Should().Be(esperado);
        }
    }
}