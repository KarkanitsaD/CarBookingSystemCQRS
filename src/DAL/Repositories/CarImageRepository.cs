using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace DAL.Repositories
{
    public class CarImageRepository : Repository<CarImageEntity>, ICarImageRepository
    {
        public CarImageRepository(CarBookingSystemContext context) 
            : base(context)
        {
        }
    }
}