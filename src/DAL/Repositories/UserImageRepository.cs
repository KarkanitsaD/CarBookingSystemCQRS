using System;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserImageRepository : Repository<UserImageEntity>, IUserImageRepository
    {
        public UserImageRepository(CarBookingSystemContext context) : base(context)
        {
        }

        public async Task<UserImageEntity> GetByUserId(Guid userId)
        {
            return await DbSet.FirstOrDefaultAsync(i => i.UserId == userId);
        }
    }
}