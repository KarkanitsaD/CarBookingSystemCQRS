using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories.IRepositories
{
    public interface ICarRepository : IRepository<CarEntity>
    {
        Task CreateRangeAsync(IEnumerable<CarEntity> cars);
    }
}