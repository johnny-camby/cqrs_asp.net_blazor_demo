﻿using DataLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.CQRS.Customers.Commands
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
