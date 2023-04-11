using DataLayer.CQRS.Responses;
using DataLayer.Entities;

namespace DataLayer.CQRS.FullAddresses
{
    public class FullAddressCommandResponse : BaseResponse
    {
        public FullAddressCommandResponse() : base() { }
        public FullAddress FullAddress { get; set; } = default!;
    }
}
