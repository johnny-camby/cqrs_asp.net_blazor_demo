using DataLayer.Entities;
using DataLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CQRS.Customers.Queries
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerListVm>>
    {
        private readonly IDataRepository<Customer> _customerRepository;

        public GetCustomerListQueryHandler(IDataRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerListVm>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.ListAllAsync();

            return customers.Select(customer => new CustomerListVm { }).ToList();
        }
    }
}
