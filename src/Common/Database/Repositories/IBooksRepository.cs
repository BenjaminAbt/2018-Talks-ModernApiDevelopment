using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Abstractions;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories
{
    public interface IBooksRepository : IBaseRepository<BookEntity>
    {
        Task<BookEntity> AddAsync(string name, double price);
    }
}