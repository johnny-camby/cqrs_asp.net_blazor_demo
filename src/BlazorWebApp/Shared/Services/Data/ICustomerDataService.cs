
using BlazorWebApp.Shared.ViewModels;

namespace BlazorWebApp.Shared.Services.Data
{
    public interface ICustomerDataService
    {
        Task<List<CustomerListViewModel>> GetCustomers();
        Task<CustomerDetailsViewModel> GetCustomerDetails(Guid id);
        Task<ApiResponse<Guid>> CreateCustomer(CustomerCreateViewModel customerCreateViewModel);
        Task<ApiResponse<Guid>> UpdateCustomer(CustomerDetailsViewModel customerDetailsView);
        Task<ApiResponse<Guid>> DeleteCustomer(Guid id);
    }
}
