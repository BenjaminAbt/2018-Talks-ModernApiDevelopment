using System;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Abstractions;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories
{
    public interface IAuthorsRepository : IBaseRepository<AuthorEntity>
    {
        Task<AuthorEntity> AddAsync(string firstName, string lastName, DateTime dateOfBirth);
    }
}