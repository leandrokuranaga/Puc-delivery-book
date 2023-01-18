using System;

namespace deliverybook.API.ViewModel
{
    public class LocalLivroViewModel
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid LocalId { get; set; }
        public bool Disponivel { get; set; }

        public virtual LivroTrocaViewModel Produto { get; set; }
        public virtual LocalizacaoViewModel Local { get; set; }
    }
}