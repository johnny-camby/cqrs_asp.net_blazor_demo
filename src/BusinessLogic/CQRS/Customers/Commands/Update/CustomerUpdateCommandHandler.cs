

using AutoMapper;
using BusinessLogic.Exceptions;
using DataLayer.Entities;
using DataLayer.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Customers.Commands.Update
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommandRequest>
    {
        private readonly IMapper _mapper;
        private readonly IDataRepository<Customer> _customerRepository;

        public CustomerUpdateCommandHandler(IMapper mapper,
            IDataRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(CustomerUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _customerRepository.GetByIdAsync(request.Id);

            if (customerToUpdate == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            _mapper.Map(request, customerToUpdate, typeof(CustomerUpdateCommandRequest), typeof(Customer));
            await _customerRepository.UpdateAsync(customerToUpdate);
            return Unit.Value;
        }
    }
}
