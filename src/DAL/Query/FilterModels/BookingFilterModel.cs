using System;

namespace DAL.Query.FilterModels
{
    public class BookingFilterModel : PaginationFilterModel
    {
        public Guid? UserId { get; set; }

        public Guid? CountryId { get; set; }

        public Guid? CityId { get; set; }

        public Guid? BookingPointId { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public bool? Current { get; set; }
    }
}