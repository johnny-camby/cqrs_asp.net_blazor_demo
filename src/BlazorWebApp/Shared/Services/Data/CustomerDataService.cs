

using AutoMapper;
using Blazored.LocalStorage;
using BlazorWebApp.Shared.ViewModels;

namespace BlazorWebApp.Shared.Services.Data
{
    public class CustomerDataService : MainDataService, ICustomerDataService
    {
        private readonly IMapper _mapper;
        public CustomerDataService(IMapper mapper, IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            _mapper = mapper;
        }

        public async Task<List<CustomerListViewModel>> GetCustomers()
        {
            var customers = await _client.GetCustomersAsync();
            var mappedCustomers = _mapper.Map<ICollection<CustomerListViewModel>>(customers);
            return mappedCustomers.ToList();
        }

        public async Task<CustomerDetailsViewModel> GetCustomerDetails(Guid id)
        {
            var customer = await _client.GetCustomerAsync(id);
            var mappedCustomer = _mapper.Map<CustomerDetailsViewModel>(customer);
            return mappedCustomer;
        }

        public async Task<ApiResponse<Guid>> CreateCustomer(CustomerCreateViewModel customerCreateViewModel)
        {
            try
            {
                var customerCreateCmd = _mapper.Map<CustomerCreateCommandRequest>(customerCreateViewModel);
                var newId = await _client.AddCustomerAsync(customerCreateCmd);
                return new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> UpdateCustomer(CustomerDetailsViewModel customerDetailsView)
        {
            try
            {
                var customerUpdateCmd = _mapper.Map<CustomerUpdateCommandRequest>(customerDetailsView);
                await _client.UpdateCustomerAsync(customerUpdateCmd);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteCustomer(Guid id)
        {
            try
            {
                await _client.DeleteCustomerAsync(id);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }        
    }
}
