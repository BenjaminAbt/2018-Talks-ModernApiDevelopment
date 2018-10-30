using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Mappers;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.InMemoryQueryHandlers.Books
{
    public class GetAllBooksFromInMemoryQueryHandler : IRequestHandler<GetAllBooksQuery, IList<Book>>
    {
        private readonly IBooksRepository _booksRepository;

        public GetAllBooksFromInMemoryQueryHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<IList<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            // load from database
            IQueryable<BookEntity> entities = await _booksRepository.GetAllAsync();

            // map
            IList<Book> books = entities.AsEnumerable().Select(BookMapper.MapToModel).ToList();

            // return
            return books;
        }
    }
}