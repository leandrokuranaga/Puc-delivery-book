using System.Collections.Generic;

namespace deliverybook.API.ViewModel
{
    public class DetalhesViewModel : LivroViewModel
    {
        public string Isbn10 { get; set; }
        public int Paginas { get; set; }
        public int Ano { get; set; }
        public int Avaliacao { get; set; }
        public string Autores { get; set; }
        public string Editora { get; set; }
        public string Lingua { get; set; }
        public string Descricao { get; set; }
        public IDictionary<string, string> Capitulos { get; set; }
        public bool Alugavel { get; set; }
    }
}