using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using Business.Helpers;
using Business.Options;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.CommandsHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;

        private readonly IRoleRepository _roleRepository;

        private readonly IRoleUserRepository _roleUserRepository;

        private readonly IUserImageRepository _userImageRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUserImageRepository userImageRepository, IRoleRepository roleRepository, IRoleUserRepository roleUserRepository)
        {
            _userRepository = userRepository;
            _userImageRepository = userImageRepository;
            _roleRepository = roleRepository;
            _roleUserRepository = roleUserRepository;
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

            var role = await _roleRepository.GetRoleByTitleAsync(Roles.UserRole);
            await _roleUserRepository.CreateAsync(new RoleUserEntity { RoleId = role.Id, UserId = user.Id });

            return Unit.Value;
        }
    }
}