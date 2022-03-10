using Application.Models.ResponseModels;
using MediatR;

namespace Application.CQRS.Commands
{
    public class LoginUserCommand : IRequest<LoginResponseModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}