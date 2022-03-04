using System.Threading.Tasks;
using DAL.Entities;
using DAL.Query;
using DAL.Query.FilterModels;

namespace DAL.Repositories.IRepositories
{
    public interface IBookingPointRepository : IRepository<BookingPointEntity>
    {
        Task<PageResult<BookingPointEntity>> GetPageListAsync(BookingPointFilterModel bookingFilterModel);
    }
}