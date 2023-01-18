using System.Collections.Generic;

namespace deliverybook.Domain.Model.Localizacao
{
    public class Produto : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Autores { get; set; }
        public ICollection<LocalProduto> LocalProdutos { get; set; }
    }
}