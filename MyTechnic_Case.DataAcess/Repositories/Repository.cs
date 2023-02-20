using Microsoft.EntityFrameworkCore;
using MyTechnic_Case.Core.Repositories;
using System.Linq.Expressions;

namespace MyTechnic_Case.DataAcess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private MyTechnic_CaseDbContext context;

        public Repository(MyTechnic_CaseDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(Guid id)
        {
            return context.Set<TEntity>().FindAsync(id);
        }

        public ValueTask<TEntity> GetByWorkOrderNumberAsync(String workordernumber)
        {
            return context.Set<TEntity>().FindAsync(workordernumber);
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public void Update(TEntity entity)
        {
            try
            {
				context.Attach(entity);
				context.Entry(entity).State = EntityState.Modified;
			}
            catch (Exception ex)
            {

                throw;
            }
            
        }

    }
}
