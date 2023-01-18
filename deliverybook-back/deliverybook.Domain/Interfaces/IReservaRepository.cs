using deliverybook.Domain.Model.Localizacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface IReservaRepository : IRepository<Reserva>
    {
        Task<IEnumerable<Reserva>> ObterReservasPorUser(string userId);
    }
}