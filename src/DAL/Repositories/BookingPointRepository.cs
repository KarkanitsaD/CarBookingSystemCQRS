using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Query;
using DAL.Query.FilterModels;
using DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BookingPointRepository : Repository<BookingPointEntity>, IBookingPointRepository
    {
        public BookingPointRepository(CarBookingSystemContext context) : base(context)
        {
        }

        public async Task<PageResult<BookingPointEntity>> GetPageListAsync(BookingPointFilterModel filterModel)
        {
            var result = DbSet.AsQueryable();
            result = Filter(result, filterModel);

            var count = await result.CountAsync();

            result = result.Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                .Take(filterModel.PageSize);

            result.Include(b => b.City)
                .ThenInclude(c => c.Country);

            return new PageResult<BookingPointEntity> { Items = await result.ToListAsync(), ItemsTotalCount = count };
        }

        private IQueryable<BookingPointEntity> Filter(IQueryable<BookingPointEntity> result, BookingPointFilterModel filterModel)
        {
            if (filterModel.CityId != null)
            {
                result = result.Where(p => p.CityId == filterModel.CityId);
            }
            else if (filterModel.CityId == null && filterModel.CountryId != null)
            {
                result = result.Include(p => p.City).Where(p => p.City.CountryId == filterModel.CountryId);
            }

            result = result.Include(p => p.Cars)
                .ThenInclude(c => c.Bookings)
                .Where(p => p.Cars.Count(c => c.Bookings
                    .Count(b => !(b.PickUpTime > filterModel.PickUpTime && b.PickUpTime > filterModel.HandOverTime
                                  || b.HandOverTime < filterModel.HandOverTime && b.HandOverTime < filterModel.PickUpTime)) > 0) > 0);

            return result;
        }
    }
}