using System;

namespace Application.Models.ViewModels
{
    public class BookingPointViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}