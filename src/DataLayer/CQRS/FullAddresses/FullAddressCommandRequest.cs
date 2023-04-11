using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.CQRS.FullAddresses
{
    public class FullAddressCommandRequest : IRequest<FullAddressCommandResponse>
    {
        public string Address { get; set; }
    }
}
