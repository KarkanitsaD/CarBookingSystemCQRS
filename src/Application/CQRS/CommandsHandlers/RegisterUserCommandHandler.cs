using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using Business.Helpers;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.CommandsHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserImageRepository _userImageRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUserImageRepository userImageRepository)
        {
            _userRepository = userRepository;
            _userImageRepository = userImageRepository;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existedUser = await _userRepository.GetUserByEmail(request.Email);
            if (existedUser != null)
            {
                //401
                throw new Exception();
            }

            var user = new UserEntity
            {
                Email = request.Email,
                PasswordHash = PasswordHasher.GeneratePasswordHash(request.Password),
                Name = request.Name,
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber
            };

            user = await _userRepository.CreateAsync(user);

            if (!string.IsNullOrEmpty(request.ImageBase64Content))
            {
                var userImage = new UserImageEntity
                {
                    UserId = user.Id,
                    Base64Content = request.ImageBase64Content
                };

                await _userImageRepository.CreateAsync(userImage);
            }

            return Unit.Value;
        }
    }
}