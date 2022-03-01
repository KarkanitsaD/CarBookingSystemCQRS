using System.Threading.Tasks;
using AutoMapper;
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

        //[HttpGet]
        //public async Task<IActionResult> GetUserPage([FromQuery] UserFilterModel userFilterModel)
        //{

        //}

    }
}