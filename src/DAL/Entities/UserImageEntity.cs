using System;

namespace DAL.Entities
{
    public class UserImageEntity : ImageEntity
    {
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
    }
}