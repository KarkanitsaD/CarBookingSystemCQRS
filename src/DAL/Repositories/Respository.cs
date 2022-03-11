using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {
        protected readonly CarBookingSystemContext Context;

        protected readonly DbSet<TEntity> DbSet;

        public Repository(CarBookingSystemContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var deletedEntity = DbSet.Remove(entity);

            await Context.SaveChangesAsync();

            return deletedEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = DbSet.Update(entity);

            await Context.SaveChangesAsync();

            return updatedEntity.Entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = await DbSet.AddAsync(entity);

            await Context.SaveChangesAsync();

            return createdEntity.Entity;
        }
    }
}