using System.Collections.Generic;

namespace deliverybook.Infra.Entities.ItBook
{
    public class DetailsDAO : BookDAO
    {
        public string Error { get; set; }
        public string Isbn10 { get; set; }
        public string Pages { get; set; }
        public string Year { get; set; }
        public string Rating { get; set; }
        public string Desc { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public Dictionary<string, string> Pdf { get; set; }
    }
}