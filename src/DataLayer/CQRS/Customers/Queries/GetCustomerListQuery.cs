using MediatR;

namespace DataLayer.CQRS.Customers.Queries
{
    public class GetCustomerListQuery : IRequest<List<CustomerListVm>>
    {
    }
}
