using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Localizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliverybook.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> PesquisarPorLocalId(Guid localId)
        {
            return await _produtoRepository.ObterProdutosPorLocalId(localId);
        }

        public async Task<Produto> ObterPorLocalEProdutoId(Guid produtoId, Guid localId)
        {
            return await _produtoRepository.ObterPorLocalId(produtoId, localId);
        }

        public async Task<bool> Adicionar(Produto produto)
        {
            if (_produtoRepository.Buscar(f => f.Titulo.ToLower().Equals(produto.Titulo.ToLower())).Result.Any())
            {
                return false;
            }

            await _produtoRepository.Adicionar(produto);
            return true;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            if (_produtoRepository.Buscar(f => f.Titulo.ToLower().Equals(produto.Titulo.ToLower())).Result.Any())
            {
                return false;
            }

            await _produtoRepository.Atualizar(produto);
            return true;
        }

        public async Task<bool> Inativar(Produto produto)
        {
            if (produto == null)
            {
                return false;
            }

            produto.LocalProdutos.FirstOrDefault().Inativar();
            await _produtoRepository.Atualizar(produto);
            return true;
        }

        public async Task<bool> Ativar(Produto produto)
        {
            if (produto == null)
            {
                return false;
            }

            produto.LocalProdutos.FirstOrDefault().Ativar();
            await _produtoRepository.Atualizar(produto);
            return true;
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}