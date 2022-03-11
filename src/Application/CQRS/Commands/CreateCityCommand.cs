using System;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateCityCommand : IRequest<Guid>
    {
        public string Title { get; set; }

        public string CountryId { get; set; }
    }
}