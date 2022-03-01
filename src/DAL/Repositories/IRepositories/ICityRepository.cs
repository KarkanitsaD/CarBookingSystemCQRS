using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Repositories.IRepositories
{
    public interface ICityRepository : IRepository<CityEntity>
    {
        IEnumerable<CityEntity> GetAllCities();
    }
}