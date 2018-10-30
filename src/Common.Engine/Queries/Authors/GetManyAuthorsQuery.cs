using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Results.Authors;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors
{
    public class GetManyAuthorsQuery : IRequest<GetManyAuthorsQueryResult>
    {
        public int Skip { get; }
        public int Take { get; }

        public GetManyAuthorsQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}