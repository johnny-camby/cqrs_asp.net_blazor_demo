

using AutoMapper;
using DataLayer.Entities;
using DataLayer.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Customers.Commands.Create
{
    public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommandRequest, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IDataRepository<Customer> _customerRepository;

        public CustomerCreateCommandHandler(IMapper mapper,
            IDataRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(CustomerCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            customer = await _customerRepository.AddAsync(customer);

            return customer.Id;
        }
    }
}
