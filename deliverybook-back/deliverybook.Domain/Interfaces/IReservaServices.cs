using deliverybook.Domain.Model.Localizacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface IReservaServices
    {
        Task<bool> Adicionar(Guid produtoId, Guid localId);
        Task<IEnumerable<Reserva>> PesquisarPorUser();
        Task<bool> Cancelar(Guid id);
    }
}