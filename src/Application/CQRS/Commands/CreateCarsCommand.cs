using System;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateCarsCommand : IRequest<Guid[]>
    {
        public decimal PricePerDay { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal FuelConsumption { get; set; }

        public int NumberOfSeats { get; set; }

        public Guid CarTransmissionTypeId { get; set; }

        public Guid BookingPointId { get; set; }

        public int Quantity { get; set; }

        public string[] Images { get; set; }
    }
}