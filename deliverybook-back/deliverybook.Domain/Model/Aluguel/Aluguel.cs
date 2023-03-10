using deliverybook.Domain.Model.Localizacao;
using System;

namespace deliverybook.Domain.Model.Aluguel
{
    public class Aluguel : Entity
    {
        public string UserId { get; set; }
        public string Isbn13 { get; set; }
        public string LivroDigital { get; set; }
        public string Titulo { get; set; }
        public string Autores { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
