namespace deliverybook.API.ViewModel
{
    public class PodcastsViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Autores { get; set; }
        public string Tipo { get; set; }
        public int Total_Episodios { get; set; }
        public string LinkExterno { get; set; }
        public ImagemViewModel Imagem { get; set; }
    }
}