using MediatR;

namespace BusinessLogic.CQRS.Customers.Queries
{
    public class GetCustomerListQuery : IRequest<List<CustomerListVm>>
    {
    }
}
