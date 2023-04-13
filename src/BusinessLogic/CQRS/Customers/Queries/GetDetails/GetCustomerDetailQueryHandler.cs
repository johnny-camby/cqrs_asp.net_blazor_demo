using AutoMapper;
using BusinessLogic.CQRS.FullAddresses.Dtos;
using BusinessLogic.Exceptions;
using DataLayer.Entities;
using DataLayer.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Customers.Queries.GetDetails
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQueryRequest, CustomerDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IDataRepository<Customer> _customerRepository;
        public GetCustomerDetailQueryHandler(IMapper mapper,
            IDataRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDetailVm> Handle(GetCustomerDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            var customerDetail = _mapper.Map<CustomerDetailVm>(customer);
            var fullAddress = customerDetail.FullAddress;
            if (fullAddress != null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }
            customerDetail.FullAddress = _mapper.Map<FullAddressDto>(fullAddress);
            return customerDetail;
        }
    }
}
