using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using DAL;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CQRS.CommandsHandlers
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly CarBookingSystemContext _context;

        private readonly IHttpContextAccessor _contextAccessor;

        public CreateBookingCommandHandler(CarBookingSystemContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();

        }

        
    }
}