using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace DAL.Repositories
{
    public class CarRepository : Repository<CarEntity>, ICarRepository
    {
        public CarRepository(CarBookingSystemContext context) 
            : base(context)
        {
        }

        public async Task CreateRangeAsync(IEnumerable<CarEntity> cars)
        { 
            await DbSet.AddRangeAsync(cars);
        }
    }
}