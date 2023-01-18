using System.Collections.Generic;

namespace deliverybook.Domain.Model.Localizacao
{
    public class Local : Entity
    {
        public string Descricao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public ICollection<LocalProduto> LocalProdutos { get; set; }
    }
}