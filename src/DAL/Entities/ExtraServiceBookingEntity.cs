using System;

namespace DAL.Entities
{
    public class ExtraServiceBookingEntity
    {
        public Guid BookingId { get; set; }

        public BookingEntity Booking { get; set; }

        public Guid ExtraServiceId { get; set; }

        public ExtraServiceEntity ExtraService { get; set; }

        public int Amount { get; set; }
    }
}