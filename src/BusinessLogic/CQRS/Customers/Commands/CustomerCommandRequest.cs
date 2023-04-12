using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CQRS.Customers.Commands
{
    public class CustomerCommandRequest : IRequest<CustomerCommandResponse>
    {
        public string CustId { get; set; } = string.Empty;
    }
}
