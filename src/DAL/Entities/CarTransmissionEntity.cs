using System.Collections.Generic;

namespace DAL.Entities
{
    public class CarTransmissionEntity : Entity
    {
        public string Title { get; set; }

        public List<CarEntity> Cars { get; set; }
    }
}