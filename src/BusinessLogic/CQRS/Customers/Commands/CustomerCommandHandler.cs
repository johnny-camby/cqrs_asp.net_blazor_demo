using DataLayer.Entities;
using DataLayer.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Customers.Commands
{
    public class CustomerCommandHandler : IRequestHandler<CustomerCommandRequest, CustomerCommandResponse>
    {
        private readonly IDataRepository<Customer> _customerRepository;

        public CustomerCommandHandler(IDataRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerCommandResponse> Handle(CustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customerCommandResponse = new CustomerCommandResponse();

            return customerCommandResponse;
        }
    }
}
