using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories.IRepositories
{
    public interface IExtraServiceRepository : IRepository<ExtraServiceEntity>
    {
        Task CreateRangeAsync(IEnumerable<ExtraServiceEntity> entities);
    }
}