using System.Collections.Generic;

namespace DAL.Entities
{
    public class CountryEntity : Entity
    {
        public string Title { get; set; }

        public List<CityEntity> Cities { get; set; }
    }
}