using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Mappers
{
    public static class BookMapper
    {
        public static BookEntity MapToEntity(Book source)
        {
            return new BookEntity
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price
            };
        }
        public static Book MapToModel(BookEntity source)
        {
            return new Book
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price
            };
        }
    }
}