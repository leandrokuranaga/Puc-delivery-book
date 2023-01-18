using deliverybook.Domain.Model.Aluguel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface IAluguelRepository : IRepository<Aluguel>
    {
        Task<IEnumerable<Aluguel>> ObterAlugueisPorUser(string userId);
    }
}