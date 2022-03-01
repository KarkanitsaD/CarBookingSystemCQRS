using System;

namespace DAL.Entities
{
    public class CarLockEntity
    {
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }

        public Guid CarId { get; set; }

        public CarEntity Car { get; set; }

        public DateTime ExpirationTime { get; set; }
    }
}