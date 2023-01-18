using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Localizacao;
using deliverybook.Infra.Context;
using deliverybook.Infra.Repository;
using deliverybook.UnitTests.Comum.Faker.Domain.Model.Localizacao;
using deliverybook.UnitTests.Comum.Faker.Infra;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace deliverybook.UnitTests.Infra.Repository
{
    public class LocalRepositoryTests
    {
        private LocalizacaoContext _contexto;
        private ContextFake _contextoBase { get; }
        public IRepository<Local> IRepository { get; }

        public LocalRepositoryTests()
        {
            _contextoBase = new ContextFake("LocalRepositoryTests");
            _contexto = new LocalizacaoContext(_contextoBase.Options);
        }

        [Fact]
        public void Devera_Buscar_Local()
        {
            var esperado = LocalFaker.GerarLocalBusca();

            var repository = new LocalRepository(_contexto);
            var resultado = repository.Buscar(f => f.Latitude == esperado.Latitude && f.Longitude == esperado.Longitude);

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            resultado.Result.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public void Devera_Buscar_Local_Por_Id()
        {
            var esperado = LocalFaker.GerarLocalBusca();

            var repository = new LocalRepository(_contexto);
            var resultado = repository.ObterPorId(esperado.Id);

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            resultado.Result.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public void Devera_Obter_Todos_Locais()
        {
            var repository = new LocalRepository(_contexto);
            var resultado = repository.ObterTodos();

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            resultado.Result.Should().HaveCountGreaterOrEqualTo(4);
        }

        [Fact]
        public void Devera_Add_Novo_Local()
        {
            var local = LocalFaker.GerarLocalEstatico();

            var repository = new LocalRepository(_contexto);
            var resultado = repository.Adicionar(local);

            var check = _contexto.Locais.Find(local.Id);
            
            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            check.Should().BeEquivalentTo(local);
        }

        [Fact]
        public void Devera_Atualizar_Local()
        {
            var local = LocalFaker.GerarLocalAlteracao();
            local.Descricao = "Descrição";

            var repository = new LocalRepository(_contexto);
            var resultado = repository.Atualizar(local);

            var check = _contexto.Locais.Find(local.Id);

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            check.Should().BeEquivalentTo(local);
        }

        [Fact]
        public void Devera_Obter_Locais_Por_Produto_Id()
        {
            var repository = new LocalRepository(_contexto);
            var resultado = repository.ObterLocaisPorProdutoId(new Guid("c5559fe9-9680-4f86-8abc-0e965d221d95")).Result;

            //Assert
            resultado.Should().NotBeNull();
            resultado.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Fact]
        public void Devera_Remover_Local()
        {
            var local = LocalFaker.GerarLocalExclusao();

            var repository = new LocalRepository(_contexto);
            var resultado = repository.Remover(local.Id);

            var check = _contexto.Locais.Find(local.Id);

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            check.Should().BeNull();
        }
    }
}