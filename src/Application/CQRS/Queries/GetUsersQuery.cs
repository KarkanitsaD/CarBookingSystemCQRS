using DAL.Entities;
using DAL.Query;
using DAL.Query.FilterModels;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetUsersQuery : IRequest<PageResult<UserEntity>>
    {
        public GetUsersQuery(UserFilterModel filterModel)
        {
            FilterModel = filterModel;
        }

        public UserFilterModel FilterModel { get; set; }
    }
}