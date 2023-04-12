
using DataLayer.Entities;
using MediatR;

namespace BusinessLogic.CQRS.Customers.Commands.Update
{
    public class CustomerUpdateCommandRequest : IRequest
    {
        public Guid Id { get; set; }
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
