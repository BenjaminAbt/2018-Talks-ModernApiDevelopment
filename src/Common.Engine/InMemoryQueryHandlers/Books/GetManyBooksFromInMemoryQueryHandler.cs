using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Results;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Results.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Mappers;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.InMemoryQueryHandlers.Books
{
    public class GetManyBooksFromInMemoryQueryHandler : IRequestHandler<GetManyBooksQuery, GetManyBooksQueryResult>
    {
        private readonly IBooksRepository _booksRepository;


        public GetManyBooksFromInMemoryQueryHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<GetManyBooksQueryResult> Handle(GetManyBooksQuery request, CancellationToken cancellationToken)
        {
            // load from database
            IQueryable<BookEntity> entities = await _booksRepository.GetAllAsync(request.Skip, request.Take);
            int totalCount = await _booksRepository.CountAsync();

            // map
            IList<Book> books = entities.AsEnumerable().Select(BookMapper.MapToModel).ToList();

            // return
            return new GetManyBooksQueryResult(books, totalCount);
        }
    }
}