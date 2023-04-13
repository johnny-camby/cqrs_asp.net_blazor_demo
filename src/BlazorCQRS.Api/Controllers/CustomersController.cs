using BusinessLogic.CQRS.Customers.Commands.Create;
using BusinessLogic.CQRS.Customers.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCustomers")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<CustomerListVm>>> GetCustomers()
        {
            var dtos = await _mediator.Send(new GetCustomerListQueryRequest());
            return Ok(dtos);
        }

        [HttpPost("AddCustomer")]
        public async Task<ActionResult<Guid>> Create([FromBody] CustomerCreateCommandRequest custCreateCmdRequest)
        {
            var id  = await _mediator.Send(custCreateCmdRequest);
            return Ok(id);
        }
    }
}
