using MediatR;

namespace Application.CQRS.Commands
{
    public class RegisterUserCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageBase64Content { get; set; }
    }
}