using System.Collections.Generic;
using System.Threading.Tasks;
using Application.CQRS.Queries;
using Application.Models.ViewModels;
using AutoMapper;
using DAL.Entities;
using DAL.Query.FilterModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserPage([FromQuery] UserFilterModel model)
        {
            var usersPageResult = await _mediator.Send(new GetUsersQuery(model));

            var users = _mapper.Map<List<UserEntity>, List<UserViewModel>>(usersPageResult.Items);

            return Ok(new { users, usersPageResult.ItemsTotalCount });
        }

    }
}