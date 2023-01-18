using deliverybook.Domain.Model.Localizacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorLocalId(Guid localId);
        Task<Produto> ObterPorLocalId(Guid produtoId, Guid localId);
    }
}