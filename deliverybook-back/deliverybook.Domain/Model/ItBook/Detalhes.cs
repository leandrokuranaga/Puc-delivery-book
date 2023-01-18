using System.Collections.Generic;

namespace deliverybook.Domain.Model.ItBook
{
    public class Detalhes : Livro
    {
        public string Erro { get; set; }
        public string Isbn10 { get; set; }
        public int Paginas { get; set; }
        public int Ano { get; set; }
        public int Avaliacao { get; set; }
        public string Descricao { get; set; }
        public string Autores { get; set; }
        public string Editora { get; set; }
        public string Lingua { get; set; }
        public IDictionary<string, string> Capitulos { get; set; }
        public bool Alugavel { get; set; }
        public List<string> Cap { get; set; }
        private const string NoError = "0";


        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Erro) && !NoError.Equals(Erro);
        }

        public void IsRentable()
        {
            if (Cap!= null && Cap.Count > 0)
                Alugavel = Cap.FindAll(x => x.EndsWith(".pdf")).Count > 0;
        }
    }
}