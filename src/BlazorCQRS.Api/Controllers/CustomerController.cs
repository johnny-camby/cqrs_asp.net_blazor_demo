using BusinessLogic.CQRS.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCustomers")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<CustomerListVm>>> GetCustomers()
        {
            var dtos = await _mediator.Send(new GetCustomerListQuery());
            return Ok(dtos);
        }
    }
}
