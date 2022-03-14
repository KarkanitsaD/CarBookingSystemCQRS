using System;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories.IRepositories
{
    public interface IUserImageRepository : IRepository<UserImageEntity>
    {
        Task<UserImageEntity> GetByUserId(Guid userId);
    }
}