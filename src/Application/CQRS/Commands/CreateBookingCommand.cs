using System;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateBookingCommand : IRequest<Guid>
    {
        public DateTime BookingTime { get; set; }

        public DateTime PickUpTime { get; set; }

        public DateTime HandOverTime { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Guid CarId { get; set; }

        public Guid[] ExtraServicesIdentifiers { get; set; }
    }
}