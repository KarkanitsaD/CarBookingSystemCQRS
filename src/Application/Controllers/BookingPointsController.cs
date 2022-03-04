using System.Collections.Generic;
using System.Threading.Tasks;
using Application.CQRS.Queries;
using Application.ViewModels;
using AutoMapper;
using DAL.Entities;
using DAL.Query.FilterModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingPointsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public BookingPointsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingPoints([FromQuery] BookingPointFilterModel bookingPointFilter)
        {
            var result = await _mediator.Send(new GetBookingPointsQuery(bookingPointFilter));

            var bookingPoints = _mapper.Map<List<BookingPointEntity>, List<BookingPointViewModel>>(result.Items);

            return Ok(new { bookingPoints, result.ItemsTotalCount });
        }
    }
}