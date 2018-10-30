using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.ODataApi.Controllers
{
    public class AuthorsController : ODataController
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [EnableQuery]
        public async Task<ActionResult<IEnumerable<AuthorApiViewModel>>> Get()
        {
            IList<Author> result = await _mediator.Send(new GetAllAuthorsQuery());

            IEnumerable<AuthorApiViewModel> viewModels = result.Select(AuthorApiMapper.MapToApiModel);
            return Ok(viewModels);
        }

        [EnableQuery]
        public async Task<ActionResult<AuthorApiViewModel>> Get([FromODataUri]Guid key)
        {
            Author result = await _mediator.Send(new GetAuthorByIdQuery(key));

            if (result is null)
            {
                return NotFound(key);
            }

            AuthorApiViewModel viewModel = AuthorApiMapper.MapToApiModel(result);
            return Ok(viewModel);
        }
    }
}
