using DataLayer.Entities;
using DataLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CQRS.FullAddresses.Commands
{
    public class FullAddressCommandHandler : IRequestHandler<FullAddressCommandRequest, FullAddressCommandResponse>
    {
        private readonly IDataRepository<Customer> _customerRepository;

        public FullAddressCommandHandler(IDataRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<FullAddressCommandResponse> Handle(FullAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var fullAddressCmdResponse = new FullAddressCommandResponse();
            return fullAddressCmdResponse;
        }
    }
}
