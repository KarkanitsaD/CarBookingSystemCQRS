using System.Threading.Tasks;
using DAL.Entities;
using DAL.Query;
using DAL.Query.FilterModels;

namespace DAL.Repositories.IRepositories
{
    public interface IBookingRepository : IRepository<BookingEntity>
    {
        Task<PageResult<BookingEntity>> GetPageListAsync(BookingFilterModel filter);
    }
}