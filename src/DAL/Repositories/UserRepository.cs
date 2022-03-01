﻿using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Query;
using DAL.Query.FilterModels;
using DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(CarBookingSystemContext context) : base(context)
        {
        }

        public async Task<PageResult<UserEntity>> GetPageListAsync(UserFilterModel userFilterModel)
        {
            var result = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(userFilterModel.Email))
            {
                result = result.Where(u => u.Email.StartsWith(userFilterModel.Email));
            }

            if (!string.IsNullOrEmpty(userFilterModel.Name))
            {
                result = result.Where(u => u.Name.StartsWith(userFilterModel.Name));
            }

            if (!string.IsNullOrEmpty(userFilterModel.Surname))
            {
                result = result.Where(u => u.Surname.StartsWith(userFilterModel.Surname));
            }

            if (userFilterModel.MinimalNumberOfBookings != null)
            {
                result = result.Include(u => u.Bookings)
                    .Where(u => u.Bookings.Count >= userFilterModel.MinimalNumberOfBookings);
            }

            if (userFilterModel.MaximumNumberOfBookings != null)
            {
                result = result.Include(u => u.Bookings)
                    .Where(u => u.Bookings.Count <= userFilterModel.MaximumNumberOfBookings);
            }

            result = result.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role);

            var items = await result.ToListAsync();

            var count = items.Count;

            return new PageResult<UserEntity>
            { Items = items.Skip((userFilterModel.PageIndex - 1) * userFilterModel.PageSize).Take(userFilterModel.PageSize), ItemsTotalCount = count };
        }
    }
}