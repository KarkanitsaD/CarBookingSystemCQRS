namespace Application.Models.RequestModels
{
    public class ExtraServiceCreateBookingPointRequestModel
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public int MaximumAmountInBooking { get; set; }

        public bool IsAvailable { get; set; }
    }
}