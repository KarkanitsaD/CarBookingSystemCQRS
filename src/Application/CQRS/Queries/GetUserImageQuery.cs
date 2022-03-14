using System;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetUserImageQuery : IRequest<string>
    {
        public GetUserImageQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}