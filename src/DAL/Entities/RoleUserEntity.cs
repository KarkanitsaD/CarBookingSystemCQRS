using System;

namespace DAL.Entities
{
    public class RoleUserEntity
    {
        public Guid RoleId { get; set; }
        
        public RoleEntity Role { get; set; }

        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
    }
}