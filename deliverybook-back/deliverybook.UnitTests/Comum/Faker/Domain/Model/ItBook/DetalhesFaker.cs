using Bogus;
using deliverybook.Domain.Model.ItBook;
using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Domain.Model.ItBook
{
    public static class DetalhesFaker
    {
        public static Faker<Detalhes> GerarDetalhesEstatico { get; } =
           new Faker<Detalhes>()
               .RuleFor(p => p.Erro, f => "0")
               .RuleFor(p => p.Titulo, f => "The Definitive Guide to MongoDB, 3rd Edition")
               .RuleFor(p => p.SubTitulo, f => "A complete guide to dealing with Big Data using MongoDB")
               .RuleFor(p => p.Isbn13, f => "9781484211830")
               .RuleFor(p => p.Valor, f => "$49.99")
               .RuleFor(p => p.UrlImagem, f => "https://itbook.store/img/books/9781484211830.png")
               .RuleFor(p => p.Url, f => "https://itbook.store/books/9781484211830")
               .RuleFor(p => p.Autores, "David Hows, Eelco Plugge, Peter Membrey, Tim Hawkins")
               .RuleFor(p => p.Editora, "Apress")
               .RuleFor(p => p.Lingua, "English")
               .RuleFor(p => p.Isbn10, "1484211839")
               .RuleFor(p => p.Paginas, f => 376)
               .RuleFor(p => p.Ano, f => 2015)
               .RuleFor(p => p.Avaliacao, f => 4)
               .RuleFor(p => p.Capitulos, new Dictionary<string, string>())
               .RuleFor(p => p.Cap, new List<string>())
               .RuleFor(p => p.Descricao, f => "The Definitive Guide to MongoDB, Third Edition, is updated for MongoDB 3 and includes all of the latest MongoDB features, including the aggregation framework introduced in version 2.2 and hashed indexes in version 2.4. The Third Edition also now includes Node.js along with Python.MongoDB is the most...");

        public static Faker<Detalhes> GerarDetalhesComPdfEstatico { get; } =
           new Faker<Detalhes>()
               .RuleFor(p => p.Erro, f => "0")
               .RuleFor(p => p.Titulo, f => "MongoDB in Action, 2nd Edition")
               .RuleFor(p => p.SubTitulo, f => "Covers MongoDB version 3.0")
               .RuleFor(p => p.Isbn13, f => "9781617291609")
               .RuleFor(p => p.Valor, f => "$19.99")
               .RuleFor(p => p.UrlImagem, f => "https://itbook.store/img/books/9781617291609.png")
               .RuleFor(p => p.Url, f => "https://itbook.store/books/9781617291609")
               .RuleFor(p => p.Autores, "Kyle Banker, Peter Bakkum, Shaun Verch, Douglas Garrett, Tim Hawkins")
               .RuleFor(p => p.Editora, "Manning")
               .RuleFor(p => p.Lingua, "English")
               .RuleFor(p => p.Isbn10, "1617291609")
               .RuleFor(p => p.Paginas, f => 480)
               .RuleFor(p => p.Ano, f => 2016)
               .RuleFor(p => p.Avaliacao, f => 4)
               .RuleFor(p => p.Capitulos, PdfFaker.GerarPdfs())
                .RuleFor(p => p.Cap, PdfFaker.GerarPdfValues())
               .RuleFor(p => p.Descricao, f => "MongoDB in Action, 2nd Edition is a completely revised and updated version. It introduces MongoDB 3.0 and the document-oriented database model. This perfectly paced book gives you both the big picture you'll need as a developer and enough low-level detail to satisfy system engineers.MongoDB in Actio...");

        public static Faker<Detalhes> GerarDetalhesErro { get; } =
           new Faker<Detalhes>()
               .RuleFor(p => p.Erro, f => "1");
    }
}