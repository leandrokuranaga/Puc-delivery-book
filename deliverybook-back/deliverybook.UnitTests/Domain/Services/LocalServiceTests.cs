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
    public class LocalServicesTests
    {
        public Mock<ILocalRepository> _localRepository;

        public LocalServicesTests()
        {
            _localRepository = new Mock<ILocalRepository>();
        }

        [Fact]
        public async Task Devera_retornar_todos_locais()
        {
            //Arrange
            var esperado = LocalFaker.GerarLocaisListaEstatica();
            _localRepository.Setup(x => x.ObterTodos())
                            .ReturnsAsync(esperado);

            //Act
            var service = new LocalServices(_localRepository.Object);
            var response = await service.ObterTodos();

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_retornar_local_por_produtoId()
        {
            //Arrange
            var esperado = LocalFaker.GerarLocaisListaEstatica().FirstOrDefault();
            _localRepository.Setup(x => x.ObterLocaisPorProdutoId(It.IsAny<Guid>()))
                            .ReturnsAsync(new List<Local> { esperado });
            var produtoId = new Guid("533468aa-edd3-4aff-ae82-344c97c2d53e");

            //Act
            var service = new LocalServices(_localRepository.Object);
            var response = await service.PesquisarPorProdutoId(produtoId);

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public async Task Devera_adicionar_Local_true()
        {
            //Arrange
            var esperado = LocalFaker.GerarLocaisListaEstatica().FirstOrDefault();
            _localRepository.Setup(moq => moq.Buscar(It.IsAny<Expression<Func<Local, bool>>>())).ReturnsAsync(new List<Local>());
            _localRepository.Setup(x => x.Adicionar(It.IsAny<Local>()));

            //Act
            var service = new LocalServices(_localRepository.Object);
            var response = await service.Adicionar(esperado);

            //Assert
            response.Should().BeTrue();
            _localRepository.Verify(x => x.Adicionar(It.IsAny<Local>()), Times.Once);
        }

        [Fact]
        public async Task Nao_Devera_adicionar_Local_false()
        {
            //Arrange
            var esperado = LocalFaker.GerarLocaisListaEstatica().FirstOrDefault();
            _localRepository.Setup(moq => moq.Buscar(It.IsAny<Expression<Func<Local, bool>>>())).ReturnsAsync(new List<Local> { esperado });

            //Act
            var service = new LocalServices(_localRepository.Object);
            var response = await service.Adicionar(esperado);

            //Assert
            response.Should().BeFalse();
            _localRepository.Verify(x => x.Adicionar(It.IsAny<Local>()), Times.Never);
        }

        [Fact]
        public async Task Devera_atualizar_Local_true()
        {
            //Arrange
            var esperado = LocalFaker.GerarLocaisListaEstatica().FirstOrDefault();
            _localRepository.Setup(moq => moq.Buscar(It.IsAny<Expression<Func<Local, bool>>>())).ReturnsAsync(new List<Local>());
            _localRepository.Setup(x => x.Atualizar(It.IsAny<Local>()));

            //Act
            var service = new LocalServices(_localRepository.Object);
            var response = await service.Atualizar(esperado);

            //Assert
            response.Should().BeTrue();
            _localRepository.Verify(x => x.Atualizar(It.IsAny<Local>()), Times.Once);
        }

        [Fact]
        public async Task Nao_Devera_atualizar_Local_false()
        {
            //Arrange
            var esperado = LocalFaker.GerarLocaisListaEstatica().FirstOrDefault();
            _localRepository.Setup(moq => moq.Buscar(It.IsAny<Expression<Func<Local, bool>>>())).ReturnsAsync(new List<Local> { esperado });

            //Act
            var service = new LocalServices(_localRepository.Object);
            var response = await service.Atualizar(esperado);

            //Assert
            response.Should().BeFalse();
            _localRepository.Verify(x => x.Atualizar(It.IsAny<Local>()), Times.Never);
        }
    }
}