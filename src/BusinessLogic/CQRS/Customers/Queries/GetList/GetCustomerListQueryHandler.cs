using AutoMapper;
using DataLayer.Entities;
using DataLayer.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Customers.Queries.GetList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQueryRequest, List<CustomerListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IDataRepository<Customer> _customerRepository;

        public GetCustomerListQueryHandler(IMapper mapper,
            IDataRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerListVm>> Handle(GetCustomerListQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.ListAllAsync();

            return _mapper.Map<List<CustomerListVm>>(customers);
        }
    }
}
