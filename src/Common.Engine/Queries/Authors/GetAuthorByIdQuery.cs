using System;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public GetAuthorByIdQuery(Guid authorId)
        {
            AuthorId = authorId;
        }

        public Guid AuthorId { get;  }
    }
}