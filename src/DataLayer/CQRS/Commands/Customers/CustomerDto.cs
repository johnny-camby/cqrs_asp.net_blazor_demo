using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.CQRS.Commands.Customers
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string CustId { get; set; } = string.Empty;

    }
}
