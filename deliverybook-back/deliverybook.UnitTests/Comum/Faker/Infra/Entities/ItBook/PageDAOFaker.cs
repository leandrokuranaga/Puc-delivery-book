using deliverybook.Infra.Entities.ItBook;

namespace deliverybook.UnitTests.Comum.Faker.Infra.Entities.ItBook
{
    public class PageDAOFaker
    {
        public PageDAO GerarPageDAOEstatico()
        {
            return new PageDAO()
            {
                Error = "0",
                Total = "5",
                Books = BookDAOFaker.GerarBookListaEstatica()
            };
        }
    }
}