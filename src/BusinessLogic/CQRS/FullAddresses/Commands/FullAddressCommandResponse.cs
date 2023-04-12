using BusinessLogic.CQRS.Responses;
using DataLayer.Entities;

namespace BusinessLogic.CQRS.FullAddresses.Commands
{
    public class FullAddressCommandResponse : BaseResponse
    {
        public FullAddressCommandResponse() : base() { }
        public FullAddress FullAddress { get; set; } = default!;
    }
}
