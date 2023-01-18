using System;

namespace deliverybook.Domain.Model.Localizacao
{
    public class LocalProduto : Entity
    {
        public Guid ProdutoId { get; set; }
        public Guid LocalId { get; set; }
        public bool Disponivel { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Local Local { get; set; }

        public void Ativar()
        {
            Disponivel = true;
        }

        public void Inativar()
        {
            Disponivel = false;
        }
    }
}