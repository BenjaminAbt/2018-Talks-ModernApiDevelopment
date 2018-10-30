using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Database.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity, new()
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<IQueryable<TEntity>> GetAllAsync(int skip, int take);
        Task<int> CountAsync();
        Task<IQueryable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expression);
    }
}