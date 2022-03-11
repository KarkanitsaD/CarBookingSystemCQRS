using System;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateExtraServiceCommand : IRequest<Guid>
    {
        public Guid BookingPointId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int MaximumAmountInBooking { get; set; }

        public bool IsAvailable { get; set; }
    }
}