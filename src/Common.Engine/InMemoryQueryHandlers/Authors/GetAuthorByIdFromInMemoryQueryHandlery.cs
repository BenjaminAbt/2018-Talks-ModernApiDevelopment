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
    public class GetAuthorByIdFromInMemoryQueryHandlery : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAuthorsRepository _authorsRepository;

        public GetAuthorByIdFromInMemoryQueryHandlery(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            // load from database
            AuthorEntity entity = await _authorsRepository.GetByIdAsync(request.AuthorId);

            if (entity is null)
            {
                return null;
            }

            return AuthorMapper.MapToModel(entity);
        }
    }
}