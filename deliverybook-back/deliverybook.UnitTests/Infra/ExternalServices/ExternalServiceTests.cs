using deliverybook.Infra.ExternalServices;
using deliverybook.UnitTests.Comum.Faker.Infra.ExternalServices;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace deliverybook.UnitTests.Infra.ExternalServices
{
    public class ExternalServiceTests
    {
        public Uri _link = new Uri("http://apimock");
        public Mock<HttpMessageHandler> _handlerMock;
        public AuthenticationHeaderValue _auth;

        public ExternalServiceTests()
        {
            _auth = new AuthenticationHeaderValue("mock");
        }

        [Fact]
        public async Task Devera_retornar_get_response()
        {
            //Arrange
            _handlerMock = ExternalServiceBaseFaker.GerarOkMock();
            var esperado = "Get OK";
            var httpClient = new HttpClient(_handlerMock.Object);

            //Act
            var service = new ExternalService(httpClient);
            var response = await service.ExecutarGetAsync(_link);
            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);

            //Assert
            response.Should().NotBeNull();
            result.ContainsValue(esperado).Should().BeTrue();
        }

        [Fact]
        public async Task Devera_retornar_get_auth_response()
        {
            //Arrange
            _handlerMock = ExternalServiceBaseFaker.GerarOkAuthMock();
            var esperado = "Get Auth OK";
            var httpClient = new HttpClient(_handlerMock.Object);

            //Act
            var service = new ExternalService(httpClient);
            var response = await service.ExecutarAuthGetAsync(_link, _auth);
            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);

            //Assert
            response.Should().NotBeNull();
            result.ContainsValue(esperado).Should().BeTrue();
        }

        [Fact]
        public async Task Devera_retornar_post_response()
        {
            //Arrange
            _handlerMock = ExternalServiceBaseFaker.GerarPostMock();
            var esperado = "Post OK";
            var httpClient = new HttpClient(_handlerMock.Object);

            //Act
            var service = new ExternalService(httpClient);
            var response = await service.ExecutarPostAsync(_link, _auth);
            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);

            //Assert
            response.Should().NotBeNull();
            result.ContainsValue(esperado).Should().BeTrue();
        }

        [Fact]
        public async Task Devera_retornar_get_vazio()
        {
            //Arrange
            _handlerMock = ExternalServiceBaseFaker.GerarVazioMock();
            var httpClient = new HttpClient(_handlerMock.Object);

            //Act
            var service = new ExternalService(httpClient);
            var response = await service.ExecutarGetAsync(_link);

            //Assert
            response.Should().BeEmpty();
        }

        [Fact]
        public async Task Devera_retornar_get_auth_vazio()
        {
            //Arrange
            _handlerMock = ExternalServiceBaseFaker.GerarVazioMock();
            var httpClient = new HttpClient(_handlerMock.Object);

            //Act
            var service = new ExternalService(httpClient);
            var response = await service.ExecutarAuthGetAsync(_link, _auth);

            //Assert
            response.Should().BeEmpty();
        }

        [Fact]
        public async Task Devera_retornar_post_vazio()
        {
            //Arrange
            _handlerMock = ExternalServiceBaseFaker.GerarVazioMock();
            var httpClient = new HttpClient(_handlerMock.Object);

            //Act
            var service = new ExternalService(httpClient);
            var response = await service.ExecutarPostAsync(_link, _auth);

            //Assert
            response.Should().BeEmpty();
        }
    }
}