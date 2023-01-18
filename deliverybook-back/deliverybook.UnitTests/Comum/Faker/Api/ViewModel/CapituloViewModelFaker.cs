using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Api.ViewModel
{
    public static class CapituloViewModelFaker
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
    }
}