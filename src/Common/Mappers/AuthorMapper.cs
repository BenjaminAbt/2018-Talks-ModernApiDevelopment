using System.Linq;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorEntity MapToEntity(Author source)
        {
            return new AuthorEntity
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,
                Books = source.Books?.Select(BookMapper.MapToEntity).ToList()
            };
        }
        public static Author MapToModel(AuthorEntity source)
        {
            return new Author
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,
                Books = source.Books?.Select(BookMapper.MapToModel).ToList()
            };
        }
    }
}