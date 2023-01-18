using System.Collections.Generic;

namespace deliverybook.Infra.Entities.Spotify
{
    public class Items
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Media_type { get; set; }
        public string Publisher { get; set; }
        public int Total_episodes { get; set; }
        public ExternalLink External_urls { get; set; }
        public List<Images> Images { get; set; }
    }
}