using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Abstractions;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;
using GenFu;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories.InMemory
{
    public class BooksInMemoryRepository : BaseRepository<BookEntity>, IBooksRepository
    {
        public BooksInMemoryRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public Task<BookEntity> AddAsync(string name, double price)
        {
            BookEntity e = new BookEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price
            };

            DataContext.Books.Add(e);
            return Task.FromResult(e);
        }

        protected override ConcurrentBag<BookEntity> DbSet => DataContext.Books;
    }
}