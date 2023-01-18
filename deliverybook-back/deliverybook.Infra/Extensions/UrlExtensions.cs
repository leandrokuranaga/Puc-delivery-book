using System;

namespace deliverybook.Infra.Extensions
{
    public static class UrlExtensions
    {
        private const string _searchUri = "1.0/search/";
        private const string _booksUri = "1.0/books/";
        private const string _podcastUri = "q=Livros&type=show&market=BR&limit=10&offset=";

        public static Uri GerarSearchUrl(this string uri, string parametro, int pagina)
        {
            var builder = new UriBuilder(uri);
            if (pagina > 0)
            {
                builder.Path = $"{_searchUri}{parametro}/{pagina}";
                return builder.Uri;
            }
            builder.Path = $"{_searchUri}{parametro}";

            return builder.Uri;
        }

        public static Uri GerarBooksUrl(this string uri, string isbn)
        {
            var builder = new UriBuilder(uri)
            {
                Path = $"{_booksUri}{isbn}"
            };

            return builder.Uri;
        }

        public static Uri GerarPodcastUrl(this string uri, int pagina)
        {
            var builder = new UriBuilder(uri)
            {
                Query = $"{_podcastUri}{pagina.CalcularOffset()}"
            };

            return builder.Uri;
        }
    }
}