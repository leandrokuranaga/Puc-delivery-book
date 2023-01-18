using System;
using System.Collections.Generic;

namespace deliverybook.API.ViewModel
{
    public class LivroTrocaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Autores { get; set; }
        public ICollection<LocalLivroViewModel> LocalLivros { get; set; }
    }
}