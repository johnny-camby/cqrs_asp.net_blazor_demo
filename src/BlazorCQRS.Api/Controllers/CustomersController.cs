using BusinessLogic.CQRS.Customers.Commands.Create;
using BusinessLogic.CQRS.Customers.Commands.Delete;
using BusinessLogic.CQRS.Customers.Commands.Update;
using BusinessLogic.CQRS.Customers.Queries.GetDetails;
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
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CustomerListVm>>> GetCustomers()
        {
            var dtos = await _mediator.Send(new GetCustomerListQueryRequest());
            return Ok(dtos);
        }

        [HttpGet("{id:guid}", Name ="GetCustomer")]
        public async Task<ActionResult<CustomerDetailVm>> GetCustomerAsync(Guid id) 
        {
            var customerQuery = new GetCustomerDetailQueryRequest() { Id = id };
            return Ok(await _mediator.Send(customerQuery));
        }


        [HttpPost("AddCustomer")]
        public async Task<ActionResult<Guid>> Create([FromBody] CustomerCreateCommandRequest custCreateCmdRequest)
        {
            var id  = await _mediator.Send(custCreateCmdRequest);
            return Ok(id);
        }

        [HttpPut("UpdateCustomer")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] CustomerUpdateCommandRequest customerUpdateCommandRequest)
        {
            await _mediator.Send(customerUpdateCommandRequest);
            return NoContent();
        }

        [HttpPut("{id:guid}", Name = "DeleteCustomer")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteCustomerAsync(Guid id)
        {
            var deleteCustomerCommand = new CustomerDeleteCommandRequest() { Id = id };
            await _mediator.Send(deleteCustomerCommand);
            return NoContent();
        }
    }
}
