using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Query;
using DAL.Query.FilterModels;
using DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BookingRepository : Repository<BookingEntity>, IBookingRepository
    {
        public BookingRepository(CarBookingSystemContext context)
            : base(context)
        {
        }

        public async Task<PageResult<BookingEntity>> GetPageListAsync(BookingFilterModel filter)
        {
            var bookings = DbSet.AsQueryable();
            if (filter.BookingPointId != null)
            {
                bookings = bookings.Include(b => b.Car)
                    .Where(b => b.Car.BookingPointId == filter.BookingPointId);
            }
            else if (filter.CityId != null)
            {
                bookings = bookings.Include(b => b.Car)
                    .ThenInclude(c => c.BookingPoint)
                    .Where(b => b.Car.BookingPoint.CityId == filter.CityId);
            }
            else if (filter.CountryId != null)
            {
                bookings = bookings.Include(b => b.Car)
                    .ThenInclude(c => c.BookingPoint)
                    .ThenInclude(c => c.City)
                    .Where(b => b.Car.BookingPoint.City.CountryId == filter.CountryId);
            }

            bookings = bookings.Where(b => (filter.UserId != null && b.UserId == filter.UserId || filter.UserId == null) ||
                                           (filter.Current == null ||
                                            filter.Current == true && b.HandOverTime >= DateTime.UtcNow ||
                                            filter.Current == false && b.HandOverTime <= DateTime.UtcNow) &&
                                           (filter.MinPrice != null && filter.MaxPrice != null &&
                                            b.Price >= filter.MinPrice && b.Price <= filter.MaxPrice ||
                                            filter.MaxPrice == null ||
                                            filter.MinPrice == null));

            var count = await bookings.CountAsync();

            bookings = bookings.Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize);

            return new PageResult<BookingEntity> { Items = await bookings.ToListAsync(), ItemsTotalCount = count };
        }
    }
}