using System;

namespace deliverybook.API.ViewModel
{
    public class ReservaViewModel
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string Titulo { get; set; }
        public Guid LocalId { get; set; }
        public string DescricaoLocal { get; set; }
        public string UserId { get; set; }
        public DateTime DataReserva { get; set; }
    }
}
