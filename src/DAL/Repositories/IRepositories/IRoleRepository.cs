using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories.IRepositories
{
    public interface IRoleRepository : IRepository<RoleEntity>
    {
        Task<RoleEntity> GetRoleByTitleAsync(string title);
    }
}