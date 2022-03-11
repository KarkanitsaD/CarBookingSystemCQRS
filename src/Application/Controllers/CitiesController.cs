using System.Collections.Generic;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Application.Models.ViewModels;
using AutoMapper;
using DAL.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public CitiesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _mediator.Send(new GetAllCitiesQuery());

            var result = _mapper.Map<IEnumerable<CityEntity>, IEnumerable<CityViewModel>>(cities);

            return Ok(result);
        }

    }
}