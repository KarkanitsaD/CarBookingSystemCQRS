using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserEntity : Entity
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public List<RoleUserEntity> UserRoles { get; set; }

        public UserImageEntity UserImage { get; set; }

        public CarLockEntity CarLock { get; set; }

        public List<BookingEntity> Bookings { get; set; }
    }
}