using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Domain.Model.ItBook
{
    public static class PdfFaker
    {
        public static Dictionary<string, string> GerarPdfs()
        {
            Dictionary<string, string> pdfs = new Dictionary<string, string>
            {
                { "Chapter 1", "https://itbook.store/files/9781617291609/chapter1.pdf" },
                { "Chapter 4", "https://itbook.store/files/9781617291609/chapter4.pdf" }
            };

            return pdfs;
        }

        public static List<string> GerarPdfValues()
        {
            return new List<string>
            {
                { "https://itbook.store/files/9781617291609/chapter1.pdf" },
                { "https://itbook.store/files/9781617291609/chapter4.pdf" }
            };
        }
    }
}