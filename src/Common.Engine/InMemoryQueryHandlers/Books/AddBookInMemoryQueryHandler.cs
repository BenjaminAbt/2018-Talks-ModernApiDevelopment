using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Commands.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Mappers;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.InMemoryQueryHandlers.Books
{
    public class AddBookInMemoryQueryHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly IBooksRepository _booksRepository;

        public AddBookInMemoryQueryHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            // add to database
            BookEntity entity = await _booksRepository.AddAsync(request.Name, request.Price);

            // map
            Book book = BookMapper.MapToModel(entity);

            // return
            return book;
        }
    }
}