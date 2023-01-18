using System.Collections.Generic;

namespace deliverybook.API.ViewModel
{
    public class PaginacaoViewModel
    {
        public int Total { get; set; }
        public int Pagina { get; set; }
        public IEnumerable<LivroViewModel> Livros { get; set; }
    }
}