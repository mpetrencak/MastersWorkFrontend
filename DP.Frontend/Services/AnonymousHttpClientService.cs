using System.Net.Http.Json;

namespace DP.Frontend.Services
{
    public class AnonymousHttpClientService : IAnonymousHttpClientService
    {
        private readonly HttpClient _originalClient;

        public AnonymousHttpClientService(HttpClient originalClient)
        {
            _originalClient = originalClient;
        }

        public async Task<T> GetJsonAsync<T>(string requestUri)
        {
            var response = await _originalClient.GetAsync(requestUri);

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
