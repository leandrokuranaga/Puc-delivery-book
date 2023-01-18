using System.Collections.Generic;

namespace deliverybook.Infra.Entities.ItBook
{
    public class PageDAO
    {
        public string Error { get; set; }
        public string Total { get; set; }
        public string Page { get; set; }
        public IEnumerable<BookDAO> Books { get; set; }
    }
}