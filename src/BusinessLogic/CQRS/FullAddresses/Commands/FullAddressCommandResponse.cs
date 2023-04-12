using BusinessLogic.CQRS.FullAddresses.Dtos;
using BusinessLogic.Responses;
using DataLayer.Entities;

namespace BusinessLogic.CQRS.FullAddresses.Commands
{
    public class FullAddressCommandResponse : BaseResponse
    {
        public FullAddressCommandResponse() : base() { }
        public FullAddressDto FullAddress { get; set; } = default!;
    }
}
