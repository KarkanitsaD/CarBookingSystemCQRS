using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace DAL.Repositories
{
    public class CityRepository : Repository<CityEntity>, ICityRepository
    {
        public CityRepository(CarBookingSystemContext context) : base(context)
        {
        }

        public IEnumerable<CityEntity> GetAllCities()
        {
            return DbSet.AsEnumerable();
        }
    }
}