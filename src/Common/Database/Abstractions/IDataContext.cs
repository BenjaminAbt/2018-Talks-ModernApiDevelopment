using System.Collections.Concurrent;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Database.Abstractions
{
    public interface IDataContext
    {
        ConcurrentBag<BookEntity> Books { get; set; }
        ConcurrentBag<AuthorEntity> Authors { get; set; }
    }
}