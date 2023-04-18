

using Blazored.LocalStorage;

namespace BlazorWebApp.Shared.Services
{
    public class MainDataService
    {
        protected readonly ILocalStorageService _localStorageService;
        protected IClient _client;

        public MainDataService(IClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        protected ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex) 
           
        {
            if (ex.StatusCode == 400)
            {
                return new ApiResponse<Guid>() { Message = "Validation errors have occured.", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new ApiResponse<Guid>() { Message = "The requested item could not be found.", Success = false };
            }
            else
            {
                return new ApiResponse<Guid>() { Message = "Something went wrong, please try again.", Success = false };
            }
        }

    }
}
