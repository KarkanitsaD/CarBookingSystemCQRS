using System;
using MediatR;

namespace Application.CQRS.Commands
{
    public class UpdateCarCommand : IRequest
    {
        public Guid CarId { get; set; }

        public decimal PricePerDay { get; set; }

        public Guid[] ImagesIdentifiersToDelete { get; set; }

        public string[] NewImages { get; set; }
    }
}