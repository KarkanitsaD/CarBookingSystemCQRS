using System;

namespace Application.Models.ViewModels
{
    public class BookingViewModel
    {
        public decimal Price { get; set; }

        public DateTime BookingTime { get; set; }

        public DateTime PickUpTime { get; set; }

        public DateTime HandOverTime { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Guid CarId { get; set; }

        public Guid UserId { get; set; }
    }
}