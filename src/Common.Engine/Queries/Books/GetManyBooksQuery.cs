using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Results.Books;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books
{
    public class GetManyBooksQuery : IRequest<GetManyBooksQueryResult>
    {
        public int Skip { get; }
        public int Take { get; }

        public GetManyBooksQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}