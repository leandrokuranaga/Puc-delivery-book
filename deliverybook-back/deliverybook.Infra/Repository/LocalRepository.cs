using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Localizacao;
using deliverybook.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliverybook.Infra.Repository
{
    public class LocalRepository : Repository<Local>, ILocalRepository
    {
        public LocalRepository(LocalizacaoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Local>> ObterLocaisPorProdutoId(Guid produtoId)
        {
            return await Db.Locais.AsNoTracking()
                                .Include(p => p.LocalProdutos)
                                .ThenInclude(pp => pp.Produto)
                                .Where(x => x.LocalProdutos.Any(x => x.ProdutoId == produtoId))
                                .ToListAsync();
        }
    }
}