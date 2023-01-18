using deliverybook.Domain.Model;
using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Infra.ExternalServices
{
    public static class ServicosUrlMock
    {
        public static ServicosUrl GerarServicosUrlMock(string[] apis)
        {
            var listaUrls = new List<Urls>();
            foreach (var api in apis)
            {
                listaUrls.Add(new Urls()
                {
                    NomeApi = api,
                    Link = "http://apimock"
                });
            }

            return new ServicosUrl()
            {
                ListaUrls = listaUrls
            };
        }
    }
}