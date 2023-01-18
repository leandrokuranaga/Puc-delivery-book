using System.Net;
using System.Net.Http;

namespace deliverybook.UnitTests.Comum.Faker.Infra.ExternalServices
{
    public static class ExternalServiceBaseResponse
    {
        public static HttpResponseMessage GetResponseOK()
        {
            return GerarResponseMessage("{\"response\":\"Get OK\"}");
        }

        public static HttpResponseMessage AuthGetResponseOK()
        {
            return GerarResponseMessage("{\"response\":\"Get Auth OK\"}");
        }

        public static HttpResponseMessage PostResponseOK()
        {
            return GerarResponseMessage("{\"response\":\"Post OK\"}");
        }

        public static HttpResponseMessage ResponseVazio()
        {
            return GerarResponseMessage(string.Empty);
        }

        private static HttpResponseMessage GerarResponseMessage(string message)
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(message),
            };
        }
    }
}