using deliverybook.Domain.Model.Aluguel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface IRentableServices
    {
        Task<bool> Adicionar(string id, int dias);
        Task<IEnumerable<Aluguel>> PesquisarPorUser();
    }
}