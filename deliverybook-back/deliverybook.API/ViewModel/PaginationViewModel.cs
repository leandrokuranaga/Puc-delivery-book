namespace deliverybook.API.ViewModel
{
    public class PaginationViewModel
    {
        public int Atual { get; set; }
        public int Limite { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; }
        public string Anterior { get; set; }
        public string Proximo { get; set; }
    }
}