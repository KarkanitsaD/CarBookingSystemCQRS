using System;

namespace Business.Helpers
{
    public class BookingPriceCalculatorHelper
    {
        public decimal GetBookingPrice(DateTime pickUpDateTime, DateTime handOverDateTime, decimal pricePerDay)
        {
            var difference = (handOverDateTime - pickUpDateTime).TotalSeconds;

            var daysCount = (int)Math.Ceiling(difference / 86400);

            return new decimal((double) (pricePerDay * daysCount));
        }

        public decimal GetExtraServicePrice(decimal price, int amount)
        {
            return price * amount;
        }
    }

    public class ExtraServicePriceCalculatorModel
    {
        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}