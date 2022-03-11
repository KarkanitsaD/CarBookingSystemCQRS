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
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public CountriesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _mediator.Send(new GetAllCountriesQuery());

            var result = _mapper.Map<IEnumerable<CountryEntity>, IEnumerable<CountryViewModel>>(countries);

            return Ok(result);
        }
    }
}