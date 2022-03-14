using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Queries;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.QueriesHandlers
{
    public class GetUserImageQueryHandler : IRequestHandler<GetUserImageQuery, string>
    {
        private readonly IUserImageRepository _userImageRepository;

        public GetUserImageQueryHandler(IUserImageRepository userImageRepository)
        {
            _userImageRepository = userImageRepository;
        }

        public async Task<string> Handle(GetUserImageQuery request, CancellationToken cancellationToken)
        {
            var image = await _userImageRepository.GetByUserId(request.UserId);

            return image.Base64Content;
        }
    }
}