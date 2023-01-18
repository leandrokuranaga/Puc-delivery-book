using deliverybook.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace deliverybook.Infra.ExternalServices
{
    public class ExternalService : IExternalService
    {
        private readonly HttpClient _httpClient;

        public ExternalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ExecutarGetAsync(Uri uri)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            return await ReadAsStringAsync(response);
        }

        public async Task<string> ExecutarAuthGetAsync(Uri uri, AuthenticationHeaderValue credentials)
        {
            AddHeaders(credentials);
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            return await ReadAsStringAsync(response);
        }

        public async Task<string> ExecutarPostAsync(Uri uri, AuthenticationHeaderValue credentials)
        {
            AddHeaders(credentials);
            var requestBody = AddBody();

            HttpResponseMessage response = await _httpClient.PostAsync(uri, requestBody);
            return await ReadAsStringAsync(response);
        }

        private async Task<string> ReadAsStringAsync(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private void AddHeaders(AuthenticationHeaderValue credentials)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = credentials;
        }

        private FormUrlEncodedContent AddBody()
        {
            var requestData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            };

            return new FormUrlEncodedContent(requestData);
        }
    }
}