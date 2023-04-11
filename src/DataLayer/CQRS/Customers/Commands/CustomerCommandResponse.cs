using DataLayer.CQRS.Responses;

namespace DataLayer.CQRS.Customers.Commands
{
    public class CustomerCommandResponse : BaseResponse
    {
        public CustomerCommandResponse() : base()
        { }

        public CustomerDto Customer { get; set; } = default!;
    }
}
