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
    public class ProdutoRepositoryTests
    {
        private LocalizacaoContext _contexto;
        private ContextFake _contextoBase { get; }
        public IRepository<Produto> IRepository { get; }

        public ProdutoRepositoryTests()
        {
            _contextoBase = new ContextFake("ProdutoRepositoryTests");
            _contexto = new LocalizacaoContext(_contextoBase.Options);
        }

        [Fact]
        public void Devera_Buscar_Produto()
        {
            var esperado = ProdutoFaker.GerarProdutoBusca();

            var repository = new ProdutoRepository(_contexto);
            var resultado = repository.Buscar(f => f.Titulo.ToLower().Equals(esperado.Titulo.ToLower()));

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            resultado.Result.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public void Devera_Buscar_Produto_Por_Id()
        {
            var esperado = ProdutoFaker.GerarProdutoBusca();

            var repository = new ProdutoRepository(_contexto);
            var resultado = repository.ObterPorId(esperado.Id);

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            resultado.Result.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public void Devera_Obter_Todos_Produtos()
        {
            var repository = new ProdutoRepository(_contexto);
            var resultado = repository.ObterTodos();

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            resultado.Result.Should().HaveCountGreaterOrEqualTo(5);
        }

        [Fact]
        public void Devera_Add_Novo_Produto()
        {
            var produto = ProdutoFaker.GerarProdutoEstatico();

            var repository = new ProdutoRepository(_contexto);
            var resultado = repository.Adicionar(produto);

            var check = _contexto.Produtos.Find(produto.Id);
            
            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            check.Should().BeEquivalentTo(produto);
        }

        [Fact]
        public void Devera_Atualizar_Produto()
        {
            var produto = ProdutoFaker.GerarProdutoBusca();
            produto.Descricao = "Descrição";

            var repository = new ProdutoRepository(_contexto);
            var resultado = repository.Atualizar(produto);

            var check = _contexto.Produtos.Find(produto.Id);

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            check.Should().BeEquivalentTo(produto);
        }

        [Fact]
        public void Devera_Obter_Por_Local_Id()
        {
            var esperado = ProdutoFaker.GerarProdutoBuscaPorLocalId();

            var repository = new ProdutoRepository(_contexto);
            var resultado = repository.ObterPorLocalId(esperado.Id,
                esperado.LocalProdutos.FirstOrDefault().LocalId).Result;

            //Assert
            resultado.Should().NotBeNull();
            resultado.LocalProdutos.Should().BeEquivalentTo(esperado.LocalProdutos, options =>
                    options.Excluding(x => x.Id)
                            .Excluding(x => x.Produto)
                            .Excluding(x => x.Local));
            resultado.Should().BeEquivalentTo(esperado, options => 
                                                        options.Excluding(x => x.LocalProdutos));
        }

        [Fact]
        public void Devera_Obter_Produtos_Por_Local_Id()
        {
            var repository = new ProdutoRepository(_contexto);
            var resultado = repository.ObterProdutosPorLocalId(new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5")).Result;

            //Assert
            resultado.Should().NotBeNull();
            resultado.Should().HaveCountGreaterOrEqualTo(2);
        }

        [Fact]
        public void Devera_Atualizar_Produto_Disponibilidade()
        {
            var repository = new ProdutoRepository(_contexto);
            var produto = repository.ObterPorLocalId(new Guid("c5559fe9-9680-4f86-8abc-0e965d221d95"), 
                new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5")).Result;
            produto.LocalProdutos.FirstOrDefault().Disponivel = false;

            var resultado = repository.Atualizar(produto);

            var esperado = repository.ObterPorLocalId(new Guid("c5559fe9-9680-4f86-8abc-0e965d221d95"),
                new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5")).Result;

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            esperado.LocalProdutos.FirstOrDefault().Disponivel.Should().Be(false);
        }

        [Fact]
        public void Devera_Remover_Produto()
        {
            var produto = ProdutoFaker.GerarProdutoExclusao();

            var repository = new ProdutoRepository(_contexto);
            var resultado = repository.Remover(produto.Id);

            var check = _contexto.Produtos.Find(produto.Id);

            //Assert
            resultado.Status.Should().Be(TaskStatus.RanToCompletion);
            check.Should().BeNull();
        }
    }
}