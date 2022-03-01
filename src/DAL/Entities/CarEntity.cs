using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class CarEntity : Entity
    {
        public decimal PricePerDay { get; set; }
        
        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal FuelConsumption { get; set; }

        public int NumberOfSeats { get; set; }

        public Guid? CarTransmissionId { get; set; }

        public CarTransmissionEntity Transmission { get; set; }

        public CarLockEntity CarLock { get; set; }

        public Guid BookingPointId { get; set; }

        public BookingPointEntity BookingPoint { get; set; }

        public List<CarCarImageEntity> CarCarImages { get; set; }

        public List<BookingEntity> Bookings { get; set; }
    }
}