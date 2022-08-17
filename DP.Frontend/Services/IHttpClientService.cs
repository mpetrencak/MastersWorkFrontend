namespace DP.Frontend.Services
{
    public interface IHttpClientService
    {
        Task<T?> GetJsonAsync<T>(string requestUri);
        Task DeleteAsync(string requestUri);
        Task<HttpResponseMessage> PostJsonAsync(string requestUri, object content);
    }
}