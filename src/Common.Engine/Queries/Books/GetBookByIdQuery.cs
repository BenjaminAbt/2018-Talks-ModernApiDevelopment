using System;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public GetBookByIdQuery(Guid bookId)
        {
            BookId = bookId;
        }

        public Guid BookId { get; }
    }
}