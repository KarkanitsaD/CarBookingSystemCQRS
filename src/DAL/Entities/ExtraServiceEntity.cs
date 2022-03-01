using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class ExtraServiceEntity : Entity
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public int MaximumAmountInBooking { get; set; }

        public bool IsAvailable { get; set; }

        public Guid BookingPointId { get; set; }

        public BookingPointEntity BookingPoint { get; set; }

        public List<ExtraServiceBookingEntity> ExtraServiceBookings { get; set; }
    }
}