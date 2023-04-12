using BusinessLogic.CQRS.FileUpload.Commands.Import;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileUploadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UploadXmlAsync([FromForm] FileUploadCommandRequest fileUploadCommandRequest)
        {
            if(fileUploadCommandRequest.File != null)
            {
                try
                {
                    await _mediator.Send(fileUploadCommandRequest);

                }
                catch(Exception ex)
                {
                    //Log
                }
            }
            return NoContent();
        }
    }
}
