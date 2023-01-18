using System.Collections.Generic;

namespace deliverybook.Domain.Model.Spotify
{
    public class Audios
    {
        public string Requisicao { get; set; }
        public IEnumerable<Podcasts> Itens { get; set; }
        public Pagination Paginacao { get; set; }
    }
}