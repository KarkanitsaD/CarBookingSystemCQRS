using System.Threading.Tasks;
using Application.CQRS.Commands;
using Application.CQRS.Queries;
using DAL.Query.FilterModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings([FromBody] BookingFilterModel filter)
        {
            var result = await _mediator.Send(new GetBookingsQuery(filter));
            return Ok(result);
        }
    }
}