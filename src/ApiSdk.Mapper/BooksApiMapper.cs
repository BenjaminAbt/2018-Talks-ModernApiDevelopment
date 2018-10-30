using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;

namespace BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper
{
    public static class BooksApiMapper
    {
        public static BookApiViewModel MapToApiModel(Book source)
        {
            return new BookApiViewModel
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price
            };
        }
    }
}