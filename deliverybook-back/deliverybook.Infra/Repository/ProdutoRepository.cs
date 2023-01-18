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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(LocalizacaoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorLocalId(Guid localId)
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(p => p.LocalProdutos)
                                    .ThenInclude(pp => pp.Local)
                                    .Where(x => x.LocalProdutos.Any(x => x.LocalId == localId) && x.LocalProdutos.Any(x => x.Disponivel == true))
                                    .ToListAsync();
        }

        public async Task<Produto> ObterPorLocalId(Guid produtoId, Guid localId)
        {
            return await Db.Produtos.AsNoTracking()
                                    .Where(p => p.Id == produtoId)
                                    .Include(p => p.LocalProdutos)
                                    .ThenInclude(pp => pp.Local)
                                    .Where(x => x.LocalProdutos.Any(x => x.LocalId == localId))
                                    .FirstOrDefaultAsync();
        }
    }
}