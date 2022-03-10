using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CarCarImageRepository : Repository<CarCarImageEntity>, ICarCarImageRepository
    {
        public CarCarImageRepository(CarBookingSystemContext context) : base(context)
        {
        }

        public async Task<CarCarImageEntity> GetAsync(Guid carId, Guid imageId)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.CarId == carId && c.CarImageId == imageId);
        }

        public async Task CreateRangeAsync(IEnumerable<CarCarImageEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<CarCarImageEntity> entities)
        {
            DbSet.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }
    }
}