using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace DAL.Repositories
{
    public class CountryRepository : Repository<CountryEntity>, ICountryRepository
    {
        public CountryRepository(CarBookingSystemContext context) : base(context)
        {
        }

        public IEnumerable<CountryEntity> GetAllCountries()
        {
            return DbSet.AsEnumerable();
        }
    }
}