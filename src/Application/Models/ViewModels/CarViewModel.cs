using System;

namespace Application.Models.ViewModels
{
    public class CarViewModel
    {
        public Guid Id { get; set; }

        public decimal PricePerDay { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal FuelConsumption { get; set; }

        public int NumberOfSeats { get; set; }

        public Guid? CarTransmissionId { get; set; }
    }
}