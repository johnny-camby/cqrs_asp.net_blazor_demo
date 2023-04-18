

namespace BlazorWebApp.Shared.Services
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient => _httpClient;
        //{
        //    get { return _httpClient; }
        //}

    }
}
