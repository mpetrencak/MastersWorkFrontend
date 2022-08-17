using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace DP.Frontend.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _originalClient;
        private readonly NavigationManager _navigationManager;

        public HttpClientService(HttpClient originalClient, NavigationManager navigationManager)
        {
            _originalClient = originalClient;
            _navigationManager = navigationManager;
        }

        public async Task<T> GetJsonAsync<T>(string requestUri)
        {
            var response = await _originalClient.GetAsync(requestUri);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo(_navigationManager.Uri, true);
                return default;
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task DeleteAsync(string requestUri)
        {
            var response = await _originalClient.DeleteAsync(requestUri);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                _navigationManager.NavigateTo(_navigationManager.Uri, true);
        }

        public async Task<HttpResponseMessage> PostJsonAsync(string requestUri, object content)
        {
            var response = await _originalClient.PostAsJsonAsync(requestUri, content);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    _navigationManager.NavigateTo("/");
                    break;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo(_navigationManager.Uri, true);
            }

            return response;
        }
    }
}