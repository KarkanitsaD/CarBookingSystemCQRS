using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Repositories.IRepositories
{
    public interface ICountryRepository : IRepository<CountryEntity>
    {
        IEnumerable<CountryEntity> GetAllCountries();
    }
}