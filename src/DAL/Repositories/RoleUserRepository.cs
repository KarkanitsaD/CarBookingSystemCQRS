using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace DAL.Repositories
{
    public class RoleUserRepository : Repository<RoleUserEntity>, IRoleUserRepository
    {
        public RoleUserRepository(CarBookingSystemContext context) 
            : base(context)
        {
        }
    }
}