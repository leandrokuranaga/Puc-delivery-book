using System;
using System.Collections.Generic;

namespace deliverybook.API.ViewModel
{
    public class LocalizacaoViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public ICollection<LocalLivroViewModel> LocalLivros { get; set; }
    }
}