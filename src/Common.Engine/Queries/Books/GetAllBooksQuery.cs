using System.Collections.Generic;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books
{
    public class GetAllBooksQuery : IRequest<IList<Book>> {}
}
