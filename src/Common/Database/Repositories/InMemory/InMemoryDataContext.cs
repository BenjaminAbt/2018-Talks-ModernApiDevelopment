using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Abstractions;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;
using BenjaminAbt.ModernAPIDevelopment.Common.Extensions;
using GenFu;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories.InMemory
{
    public class InMemoryDataContext : IDataContext
    {
        public InMemoryDataContext(int authorsCount, int booksCount, int booksPerAuthorMin, int booksPerAuthorMax)
        {
            GenFu.GenFu.Configure<BookEntity>()
                .Fill(_ => _.Id)
                .Fill(_ => _.Name).AsLoremIpsumWords()
                .Fill(_ => _.Price, () => GenFu.GenFu.Random.Next(9, 99));


            List<BookEntity> books = GenFu.GenFu.ListOf<BookEntity>(booksCount);
            Books = new ConcurrentBag<BookEntity>(books);

            GenFu.GenFu.Configure<AuthorEntity>()
                .Fill(_ => _.Id)
                .Fill(_ => _.FirstName).AsFirstName()
                .Fill(_ => _.LastName).AsLastName()
                .Fill(_ => _.DateOfBirth).AsPastDate()
                .Fill(_ => _.Books, ()=> books.PickRandom(GenFu.GenFu.Random.Next(booksPerAuthorMin, booksPerAuthorMax)).ToList());

            List<AuthorEntity> authors = GenFu.GenFu.ListOf<AuthorEntity>(authorsCount);
            Authors = new ConcurrentBag<AuthorEntity>(authors);
        }

        public ConcurrentBag<BookEntity> Books { get; set; }
        public ConcurrentBag<AuthorEntity> Authors { get; set; }


    }
}