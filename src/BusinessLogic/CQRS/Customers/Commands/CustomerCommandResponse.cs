using BusinessLogic.CQRS.Customers.Dtos;
using BusinessLogic.CQRS.Responses;

namespace BusinessLogic.CQRS.Customers.Commands
{
    public class CustomerCommandResponse : BaseResponse
    {
        public CustomerCommandResponse() : base()
        { }

        public CustomerDto Customer { get; set; } = default!;
    }
}
