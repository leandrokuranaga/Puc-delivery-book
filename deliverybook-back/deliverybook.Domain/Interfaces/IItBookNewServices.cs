﻿using deliverybook.Domain.Model.ItBook;
using System.Threading.Tasks;

namespace deliverybook.Domain.Interfaces
{
    public interface IItBookNewServices
    {
        Task<Paginacao> Buscar();
    }
}