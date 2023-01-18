using deliverybook.Infra.Context;
using deliverybook.Domain.Model.Localizacao;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using deliverybook.Domain.Interfaces;

namespace deliverybook.Infra.Repository
{
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        public ReservaRepository(LocalizacaoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reserva>> ObterReservasPorUser(string userId)
        {
            return await Db.Reservas.AsNoTracking()
                                    .Where(x => x.UserId == userId)
                                    .ToListAsync();
        }
    }
}
