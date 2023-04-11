using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.CQRS.Customers.Queries
{
    public class GetCustomerListQuery : IRequest<List<CustomerListVm>>
    {
    }
}
