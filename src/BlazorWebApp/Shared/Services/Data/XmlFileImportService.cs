using AutoMapper;
using Blazored.LocalStorage;
using BlazorWebApp.Shared.ViewModels;

namespace BlazorWebApp.Shared.Services.Data
{
    public class XmlFileImportService : MainDataService, IXmlFileImportService
    {
        private readonly IMapper _mapper;
        public XmlFileImportService(IMapper mapper, IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> UpLoadXmlFle(FileUploadViewModel fileUploadViewModel)
        {
            try
            {
                var customerUpdateCmd = _mapper.Map<FileParameter>(fileUploadViewModel);
                await _client.FileUploadAsync(customerUpdateCmd);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
