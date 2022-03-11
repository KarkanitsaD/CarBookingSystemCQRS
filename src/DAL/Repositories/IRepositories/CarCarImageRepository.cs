using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories.IRepositories
{
    public interface ICarCarImageRepository : IRepository<CarCarImageEntity>
    {
        Task<CarCarImageEntity> GetAsync(Guid carId, Guid imageId);
        Task CreateRangeAsync(IEnumerable<CarCarImageEntity> entities);
        Task RemoveRangeAsync(IEnumerable<CarCarImageEntity> entities);
    }
}