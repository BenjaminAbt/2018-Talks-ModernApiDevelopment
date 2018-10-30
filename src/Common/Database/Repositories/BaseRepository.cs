using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Abstractions;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IEntity, new()
    {
        protected readonly IDataContext DataContext;

        protected BaseRepository(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        protected abstract ConcurrentBag<TEntity> DbSet { get; }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            TEntity data = DbSet.SingleOrDefault(e => e.Id == id);
            return Task.FromResult(data);
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> data = DbSet.ToList().AsQueryable();
            return Task.FromResult(data);
        }
        public async Task<IQueryable<TEntity>> GetAllAsync(int skip, int take)
        {
            IQueryable<TEntity> authors = await GetAllAsync();
            return authors.Skip(skip).Take(take);
        }

        public async Task<int> CountAsync()
        {
            IQueryable<TEntity> authors = await GetAllAsync();
            return authors.Count();
        }

        public async Task<IQueryable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> authors = await GetAllAsync();
            return authors.Where(expression);
        }
    }
}