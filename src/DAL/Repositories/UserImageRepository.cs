using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace DAL.Repositories
{
    public class UserImageRepository : Repository<UserImageEntity>, IUserImageRepository
    {
        public UserImageRepository(CarBookingSystemContext context) : base(context)
        {
        }
    }
}