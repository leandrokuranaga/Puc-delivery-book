using Moq;
using Moq.Protected;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace deliverybook.UnitTests.Comum.Faker.Infra.ExternalServices
{
    public static class ExternalServiceBaseFaker
    {
        public static Mock<HttpMessageHandler> GerarOkMock()
        {
            return CriarHttpMessageMock(ExternalServiceBaseResponse.GetResponseOK());
        }

        public static Mock<HttpMessageHandler> GerarOkAuthMock()
        {
            return CriarHttpMessageMock(ExternalServiceBaseResponse.AuthGetResponseOK());
        }

        public static Mock<HttpMessageHandler> GerarPostMock()
        {
            return CriarHttpMessageMock(ExternalServiceBaseResponse.PostResponseOK());
        }

        public static Mock<HttpMessageHandler> GerarVazioMock()
        {
            return CriarHttpMessageMock(ExternalServiceBaseResponse.ResponseVazio());
        }

        private static Mock<HttpMessageHandler> CriarHttpMessageMock(HttpResponseMessage httpResponseMessage)
        {
            Mock<HttpMessageHandler> handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
             .Protected()
             .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
             .ReturnsAsync(httpResponseMessage);

            return handlerMock;
        }
    }
}