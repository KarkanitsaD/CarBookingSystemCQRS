using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RoleRepository : Repository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(CarBookingSystemContext context) 
            : base(context)
        {
        }

        public async Task<RoleEntity> GetRoleByTitleAsync(string title)
        {
            return await DbSet.FirstOrDefaultAsync(role => role.Title == title);
        }
    }
}