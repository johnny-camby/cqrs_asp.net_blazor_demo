

using DataLayer.CQRS.Responses;

namespace DataLayer.CQRS.Commands.Customers
{
    public class CustomerCommandResponse : BaseResponse
    {
        public CustomerCommandResponse() : base()
        {}

        public CustomerDto Customer { get; set; } = default!;
    }
}
