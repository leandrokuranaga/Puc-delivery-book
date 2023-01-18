using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Localizacao;
using deliverybook.Domain.Services;
using deliverybook.UnitTests.Comum.Faker.Domain.Model.Localizacao;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace deliverybook.UnitTests.Domain.Services
{
    public class ProdutoServiceTests
    {
        public Mock<IProdutoRepository> _produtoRepository;

        public ProdutoServiceTests()
        {
            _produtoRepository = new Mock<IProdutoRepository>();
        }

        [Fact]
        public async Task Devera_retornar_produtos_por_localId()
        {
            //Arrange
            var esperado = ProdutoFaker.GerarProdutosListaEstatica();
            _produtoRepository.Setup(x => x.ObterProdutosPorLocalId(It.IsAny<Guid>()))
                            .ReturnsAsync(esperado);
            var localId = new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5");

            //Act
            var service = new ProdutoService(_produtoRepository.Object);
            var response = await service.PesquisarPorLocalId(localId);

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_adicionar_produto_true()
        {
            //Arrange
            var esperado = ProdutoFaker.GerarProdutosListaEstatica().FirstOrDefault();
            _produtoRepository.Setup(moq => moq.Buscar(It.IsAny<Expression<Func<Produto, bool>>>())).ReturnsAsync(new List<Produto>());
            _produtoRepository.Setup(x => x.Adicionar(It.IsAny<Produto>()));

            //Act
            var service = new ProdutoService(_produtoRepository.Object);
            var response = await service.Adicionar(esperado);

            //Assert
            response.Should().BeTrue();
            _produtoRepository.Verify(x => x.Adicionar(It.IsAny<Produto>()), Times.Once);
        }

        [Fact]
        public async Task Nao_Devera_adicionar_produto_false()
        {
            //Arrange
            var esperado = ProdutoFaker.GerarProdutosListaEstatica().FirstOrDefault();
            _produtoRepository.Setup(moq => moq.Buscar(It.IsAny<Expression<Func<Produto, bool>>>())).ReturnsAsync(new List<Produto> { esperado });

            //Act
            var service = new ProdutoService(_produtoRepository.Object);
            var response = await service.Adicionar(esperado);

            //Assert
            response.Should().BeFalse();
            _produtoRepository.Verify(x => x.Adicionar(It.IsAny<Produto>()), Times.Never);
        }

        [Fact]
        public async Task Devera_atualizar_produto_true()
        {
            //Arrange
            var esperado = ProdutoFaker.GerarProdutosListaEstatica().FirstOrDefault();
            _produtoRepository.Setup(moq => moq.Buscar(It.IsAny<Expression<Func<Produto, bool>>>())).ReturnsAsync(new List<Produto>());
            _produtoRepository.Setup(x => x.Atualizar(It.IsAny<Produto>()));

            //Act
            var service = new ProdutoService(_produtoRepository.Object);
            var response = await service.Atualizar(esperado);

            //Assert
            response.Should().BeTrue();
            _produtoRepository.Verify(x => x.Atualizar(It.IsAny<Produto>()), Times.Once);
        }

        [Fact]
        public async Task Nao_Devera_atualizar_produto_false()
        {
            //Arrange
            var esperado = ProdutoFaker.GerarProdutosListaEstatica().FirstOrDefault();
            _produtoRepository.Setup(moq => moq.Buscar(It.IsAny<Expression<Func<Produto, bool>>>())).ReturnsAsync(new List<Produto> { esperado });

            //Act
            var service = new ProdutoService(_produtoRepository.Object);
            var response = await service.Atualizar(esperado);

            //Assert
            response.Should().BeFalse();
            _produtoRepository.Verify(x => x.Atualizar(It.IsAny<Produto>()), Times.Never);
        }
    }
}