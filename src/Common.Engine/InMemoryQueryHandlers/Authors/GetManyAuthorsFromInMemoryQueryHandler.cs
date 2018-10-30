using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Results;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Results.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Mappers;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.InMemoryQueryHandlers.Authors
{
    public class GetManyAuthorsFromInMemoryQueryHandler : IRequestHandler<GetManyAuthorsQuery, GetManyAuthorsQueryResult>
    {
        private readonly IAuthorsRepository _authorsRepository;

        public GetManyAuthorsFromInMemoryQueryHandler(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public async Task<GetManyAuthorsQueryResult> Handle(GetManyAuthorsQuery request, CancellationToken cancellationToken)
        {
            // load from database
            IQueryable<AuthorEntity> authorEntities = await _authorsRepository.GetAllAsync(request.Skip, request.Take);
            int totalCount = await _authorsRepository.CountAsync();

            // map
            IList<Author> authors = authorEntities.AsEnumerable().Select(AuthorMapper.MapToModel).ToList();

            // return
            return new GetManyAuthorsQueryResult(authors, totalCount);
        }
    }
}