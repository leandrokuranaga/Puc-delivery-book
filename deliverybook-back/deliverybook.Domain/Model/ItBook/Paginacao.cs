using System.Collections.Generic;

namespace deliverybook.Domain.Model.ItBook
{
    public class Paginacao
    {
        public string Erro { get; set; }
        public int Total { get; set; }
        public int Pagina { get; set; }
        public IEnumerable<Livro> Livros { get; set; }

        private const string NoError = "0";

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Erro) && !NoError.Equals(Erro);
        }
    }
}