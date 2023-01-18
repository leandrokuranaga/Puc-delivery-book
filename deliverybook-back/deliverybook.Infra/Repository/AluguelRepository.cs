using deliverybook.Domain.Model.Aluguel;
using deliverybook.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using deliverybook.Domain.Interfaces;

namespace deliverybook.Infra.Repository
{
    public class AluguelRepository : Repository<Aluguel>, IAluguelRepository
    {
        public AluguelRepository(LocalizacaoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Aluguel>> ObterAlugueisPorUser(string userId)
        {
            return await Db.Alugueis.AsNoTracking()
                                    .Where(x => x.UserId == userId)
                                    .ToListAsync();
        }
    }
}
