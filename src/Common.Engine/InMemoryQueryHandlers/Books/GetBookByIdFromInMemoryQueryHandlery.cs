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
    public class GetBookByIdFromInMemoryQueryHandlery : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBooksRepository _booksRepository;

        public GetBookByIdFromInMemoryQueryHandlery(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            // load from database
            BookEntity entity = await _booksRepository.GetByIdAsync(request.BookId);

            if (entity is null)
            {
                return null;
            }

            return BookMapper.MapToModel(entity);
        }
    }
}