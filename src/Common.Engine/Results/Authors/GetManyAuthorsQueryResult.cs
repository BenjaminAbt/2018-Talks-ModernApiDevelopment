using System.Collections.Generic;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.Results.Authors
{
    public class GetManyAuthorsQueryResult
    {
        public IList<Author> Authors { get; }
        public int TotalCount { get; }

        public GetManyAuthorsQueryResult(IList<Author> authors, int totalCount)
        {
            Authors = authors;
            TotalCount = totalCount;
        }
    }
}
