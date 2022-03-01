using System.Collections.Generic;

namespace DAL.Entities
{
    public class CarImageEntity : ImageEntity
    {
        public List<CarCarImageEntity> CarImageCars { get; set; }
    }
}