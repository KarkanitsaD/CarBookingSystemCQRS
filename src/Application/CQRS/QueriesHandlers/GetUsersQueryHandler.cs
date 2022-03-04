using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Queries;
using DAL.Entities;
using DAL.Query;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.QueriesHandlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PageResult<UserEntity>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PageResult<UserEntity>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetPageListAsync(request.FilterModel);
            return users;
        }
    }
}