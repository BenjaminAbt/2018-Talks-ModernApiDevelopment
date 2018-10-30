using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.SwashbuckleApi.Controllers
{
    /// <summary>
    /// Authors Controller
    /// </summary>
    [Route("authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Authors Controller
        /// </summary>
        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns all authors
        /// </summary>
        /// <response code="200">Returns all authors from the database</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuthorApiViewModel>), (int)HttpStatusCode.OK)]    // Found
        public async Task<ActionResult<IEnumerable<AuthorApiViewModel>>> Get()
        {
            IList<Author> result = await _mediator.Send(new GetAllAuthorsQuery());

            IEnumerable<AuthorApiViewModel> viewModels = result.Select(AuthorApiMapper.MapToApiModel);
            return Ok(viewModels);
        }

        /// <summary>
        /// Gets a specific <see cref="AuthorApiViewModel"/> from given <paramref name="id"/>
        /// </summary>
        /// <param name="id">Unique ID of the author you're looking for</param>
        /// <returns>A </returns>
        /// <response code="200">The <see cref="AuthorApiViewModel"/> of given <paramref name="id"/></response>
        /// <response code="404">No author found</response>         
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AuthorApiViewModel), (int)HttpStatusCode.OK)]    // Found
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.NotFound)]    // NotFound
        public async Task<ActionResult<AuthorApiViewModel>> Get(Guid id)
        {
            Author result = await _mediator.Send(new GetAuthorByIdQuery(id));

            if (result is null)
            {
                return NotFound(id);
            }

            AuthorApiViewModel viewModel = AuthorApiMapper.MapToApiModel(result);
            return Ok(viewModel);
        }
    }
}
