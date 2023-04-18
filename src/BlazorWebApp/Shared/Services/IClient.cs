

namespace BlazorWebApp.Shared.Services
{

    public partial interface IClient
    {
       public HttpClient HttpClient { get; }
    }
}
