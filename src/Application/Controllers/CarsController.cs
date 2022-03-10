using System.Threading.Tasks;
using Application.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}