using System.Threading.Tasks;
using Application.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExtraServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExtraServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExtraService([FromBody] CreateExtraServiceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}