using System;

namespace deliverybook.Domain.Model.Localizacao
{
    public class Reserva : Entity
    {
        public Guid ProdutoId { get; set; }
        public string Titulo { get; set; }
        public Guid LocalId { get; set; }
        public string DescricaoLocal { get; set; }
        public string UserId { get; set; }
        public DateTime DataReserva { get; set; }
    }
}
