using System;

namespace DAL.Entities
{
    public class CarCarImageEntity
    {
        public Guid CarId { get; set; }

        public CarEntity Car { get; set; }

        public Guid CarImageId { get; set; }

        public CarImageEntity CarImage { get; set; }
    }
}