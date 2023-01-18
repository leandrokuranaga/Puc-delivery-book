using deliverybook.Domain.Model.Localizacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface ILocalRepository : IRepository<Local>
    {
        Task<IEnumerable<Local>> ObterLocaisPorProdutoId(Guid produtoId);
    }
}