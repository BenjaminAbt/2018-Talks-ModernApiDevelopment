using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Abstractions;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories.InMemory
{
    public class AuthorsInMemoryRepository: BaseRepository<AuthorEntity>, IAuthorsRepository
    {
        public AuthorsInMemoryRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public Task<AuthorEntity> AddAsync(string firstName, string lastName, DateTime dateOfBirth)
        {
            AuthorEntity e = new AuthorEntity
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            DataContext.Authors.Add(e);
            return Task.FromResult(e);
        }

        protected override ConcurrentBag<AuthorEntity> DbSet => DataContext.Authors;
    }
}