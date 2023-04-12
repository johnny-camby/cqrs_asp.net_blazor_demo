using DataLayer.Entities;
using MediatR;

namespace BusinessLogic.CQRS.Customers.Commands.Create
{
    public class CustomerCreateCommandRequest : IRequest<Guid>
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Guid FullAddressId { get; set; }
        public FullAddress FullAddress { get; set; }
    }
}
