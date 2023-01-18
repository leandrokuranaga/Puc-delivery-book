using deliverybook.Domain.Model.Localizacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface IProdutoService
    {
        Task<bool> Adicionar(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task<bool> Inativar(Produto produto);
        Task<bool> Ativar(Produto produto);
        Task<IEnumerable<Produto>> PesquisarPorLocalId(Guid localId);
        Task<Produto> ObterPorLocalEProdutoId(Guid produtoId, Guid localId);
    }
}