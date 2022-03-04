using System;

namespace DAL.Query.FilterModels
{
    public class BookingPointFilterModel : PaginationFilterModel
    {
        public Guid? CountryId { get; set; }

        public Guid? CityId { get; set; }

        public DateTime PickUpTime { get; set; }

        public DateTime HandOverTime { get; set; }
    }
}