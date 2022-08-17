namespace DP.Frontend.Services
{
    public interface IAnonymousHttpClientService
    {
        Task<T?> GetJsonAsync<T>(string requestUri);
    }
}
