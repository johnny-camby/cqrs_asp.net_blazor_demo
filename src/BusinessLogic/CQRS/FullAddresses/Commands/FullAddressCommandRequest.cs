using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CQRS.FullAddresses.Commands
{
    public class FullAddressCommandRequest : IRequest<FullAddressCommandResponse>
    {
        public string Address { get; set; }
    }
}
