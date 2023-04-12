using AutoMapper;
using BusinessLogic.Exceptions;
using DataLayer.Entities;
using DataLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CQRS.Customers.Commands.Delete
{
    public class CustomerDeleteCommandHandler : IRequestHandler<CustomerDeleteCommandRequest>
    {
        private readonly IMapper _mapper;
        private readonly IDataRepository<Customer> _customerRepository;

        public CustomerDeleteCommandHandler(IMapper mapper,
            IDataRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(CustomerDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _customerRepository.GetByIdAsync(request.Id);

            if (customerToDelete == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }
            await _customerRepository.DeleteAsync(customerToDelete);
            return Unit.Value;
        }
    }
}
