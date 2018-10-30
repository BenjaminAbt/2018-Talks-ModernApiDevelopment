using System.Collections.Generic;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors
{
    public class GetAllAuthorsQuery : IRequest<IList<Author>> {}
}
