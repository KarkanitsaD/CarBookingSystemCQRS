using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace DAL.Repositories
{
    public class ExtraServiceRepository : Repository<ExtraServiceEntity>, IExtraServiceRepository
    {
        public ExtraServiceRepository(CarBookingSystemContext context) 
            : base(context)
        {
        }

        public async Task CreateRangeAsync(IEnumerable<ExtraServiceEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }
    }
}