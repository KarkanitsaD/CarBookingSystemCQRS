using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class CityEntity : Entity
    {
        public string Title { get; set; }

        public int TimeOffsetInMinutes { get; set; }

        public Guid CountryId { get; set; }

        public CountryEntity Country { get; set; }

        public List<BookingPointEntity> BookingPoints { get; set; }
    }
}