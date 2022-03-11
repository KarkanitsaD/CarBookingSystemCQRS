using System;

namespace Application.Models.RequestModels
{
    public class ExtraServiceCreateBookingPointRequestModel
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public int MaximumAmountInBooking { get; set; }

        public bool IsAvailable { get; set; }
    }

    public class ExtraServiceInBookingRequestModel
    {
        public Guid ExtraServiceId { get; set; }

        public int Amount { get; set; }
    }
}