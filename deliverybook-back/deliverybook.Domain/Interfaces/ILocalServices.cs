using deliverybook.Domain.Model.Localizacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface ILocalServices
    {
        Task<bool> Adicionar(Local local);

        Task<bool> Atualizar(Local local);

        Task<IEnumerable<Local>> ObterTodos();

        Task<IEnumerable<Local>> PesquisarPorProdutoId(Guid produtoId);
    }
}