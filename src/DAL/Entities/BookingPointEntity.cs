using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class BookingPointEntity : Entity
    {
        public string Title { get; set; }

        public string Address { get; set; }

        public Guid CityId { get; set; }

        public CityEntity City { get; set; }

        public List<ExtraServiceEntity> ExtraServices { get; set; }

        public List<CarEntity> Cars { get; set; }
    }
}