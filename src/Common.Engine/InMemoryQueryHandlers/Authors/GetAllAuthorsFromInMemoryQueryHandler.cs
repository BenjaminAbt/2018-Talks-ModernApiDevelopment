using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Mappers;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.InMemoryQueryHandlers.Authors
{
    public class GetAllAuthorsFromInMemoryQueryHandler : IRequestHandler<GetAllAuthorsQuery, IList<Author>>
    {
        private readonly IAuthorsRepository _authorsRepository;

        public GetAllAuthorsFromInMemoryQueryHandler(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public async Task<IList<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            // load from database
            IQueryable<AuthorEntity> entities = await _authorsRepository.GetAllAsync();

            // map
            IList<Author> authors = entities.AsEnumerable().Select(AuthorMapper.MapToModel).ToList();

            // return
            return authors;
        }
    }
}