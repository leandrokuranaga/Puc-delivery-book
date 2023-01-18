namespace deliverybook.Domain.Model.Spotify
{
    public class Podcasts
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Autores { get; set; }
        public string Tipo { get; set; }
        public int TotalEpisodios { get; set; }
        public string LinkExterno { get; set; }
        public Imagem Imagem { get; set; }
    }
}