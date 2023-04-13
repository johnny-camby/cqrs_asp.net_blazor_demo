using AutoMapper;
using BusinessLogic.CQRS.FullAddresses.Dtos;
using DataLayer.Entities;
using DataLayer.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.FullAddresses.Commands
{
    public class FullAddressCommandHandler : IRequestHandler<FullAddressCommandRequest, FullAddressCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDataRepository<FullAddress> _fullAddressRepository;

        public FullAddressCommandHandler(IMapper mapper,
            IDataRepository<FullAddress> fullAddressRepository)
        {
            _mapper = mapper;
            _fullAddressRepository = fullAddressRepository;
        }
        public async Task<FullAddressCommandResponse> Handle(FullAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var fullAddressCmdResponse = new FullAddressCommandResponse();

            if(fullAddressCmdResponse.Success)
            {
                var fullAddress = new FullAddress { Address = request.Address };
                fullAddress = await _fullAddressRepository.AddAsync(fullAddress);
                fullAddressCmdResponse.FullAddress = _mapper.Map<FullAddressDto>(fullAddress);
            }

            return fullAddressCmdResponse;
        }
    }
}
