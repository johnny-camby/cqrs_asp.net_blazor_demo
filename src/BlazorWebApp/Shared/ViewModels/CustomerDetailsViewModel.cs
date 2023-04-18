
namespace BlazorWebApp.Shared.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public Guid Id { get; set; }
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Guid FullAddressId { get; set; }
        public FullAddressViewModel FullAddress { get; set; } = default!;
    }
}
