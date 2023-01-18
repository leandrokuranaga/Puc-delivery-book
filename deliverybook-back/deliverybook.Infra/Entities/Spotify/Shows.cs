using deliverybook.Infra.Extensions;
using System.Collections.Generic;

namespace deliverybook.Infra.Entities.Spotify
{
    public class Shows
    {
        public int Current { get; set; }
        public string Href { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public string Previous { get; set; }
        public int Total { get; set; }
        public List<Items> Items { get; set; }

        public void CurrentCalcule()
        {
            Current = Offset.CalcularPagina();
        }
    }
}