
using BlazorWebApp.Shared.ViewModels;

namespace BlazorWebApp.Shared.Services.Data
{
    public interface IXmlFileImportService
    {
        Task<ApiResponse<Guid>> UpLoadXmlFle(FileUploadViewModel fileUploadCommandRequest);
    }
}
