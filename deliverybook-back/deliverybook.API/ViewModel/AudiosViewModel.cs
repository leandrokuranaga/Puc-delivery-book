using System.Collections.Generic;

namespace deliverybook.API.ViewModel
{
    public class AudiosViewModel
    {
        public string Requisicao { get; set; }
        public IEnumerable<PodcastsViewModel> Itens { get; set; }
        public PaginationViewModel Paginacao { get; set; }
    }
}