using System.Collections.Generic;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.Results.Books
{
    public class GetManyBooksQueryResult
    {
        public IList<Book> Books { get; }
        public int TotalCount { get; }

        public GetManyBooksQueryResult(IList<Book> books, int totalCount)
        {
            Books = books;
            TotalCount = totalCount;
        }
    }
}
