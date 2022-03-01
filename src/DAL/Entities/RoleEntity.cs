using System.Collections.Generic;

namespace DAL.Entities
{
    public class RoleEntity : Entity
    {
        public string Title { get; set; }

        public List<RoleUserEntity> RoleUsers { get; set; }
    }
}