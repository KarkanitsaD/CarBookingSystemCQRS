using System;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateCountryCommand : IRequest<Guid>
    {
        public string Title { get; set; }
    }
}