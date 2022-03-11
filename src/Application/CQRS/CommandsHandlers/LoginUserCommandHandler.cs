using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using Application.Models.ResponseModels;
using Business.Helpers;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.CommandsHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseModel>
    {

        private readonly IUserRepository _userRepository;
        private readonly TokenHelper _tokenHelper;

        public LoginUserCommandHandler(IUserRepository userRepository, TokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<LoginResponseModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = PasswordHasher.GeneratePasswordHash(request.Password);
            var user = await _userRepository.GetUserByEmailAndPasswordHash(request.Email, passwordHash);
            if (user == null)
            {
                //401
                throw new Exception();
            }

            var jwt = _tokenHelper.GenerateJwt(user);

            return new LoginResponseModel(jwt);
        }
    }
}