using System.Threading.Tasks;
using DAL.Entities;
using DAL.Query;
using DAL.Query.FilterModels;

namespace DAL.Repositories.IRepositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<PageResult<UserEntity>> GetPageListAsync(UserFilterModel userFilterModel);
    }
}