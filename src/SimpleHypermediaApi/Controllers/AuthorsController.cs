using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Results.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Controllers
{
    [Route("authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("", Name = "GetAllAuthors")]
        [ProducesResponseType(typeof(IEnumerable<AuthorApiViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AuthorApiViewModel>>> GetMany(int skip = 0, int take = 3)
        {
            GetManyAuthorsQueryResult result = await _mediator.Send(new GetManyAuthorsQuery(skip, take));

            IList<AuthorApiViewModel> viewModels = result.Authors.AsEnumerable().Select(AuthorApiMapper.MapToApiModel).ToList();

            CollectionResult<AuthorApiViewModel> response =
                new CollectionResult<AuthorApiViewModel>(viewModels, skip, take, result.TotalCount);

            return Ok(response);
        }
     
        [HttpGet("{id}", Name = "GetAuthorById")]
        [ProducesResponseType(typeof(AuthorApiViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<AuthorApiViewModel>> Get(Guid id)
        {
            Author result = await _mediator.Send(new GetAuthorByIdQuery(id));

            if (result is null)
            {
                return NotFound(id);
            }

            AuthorApiViewModel viewModel = AuthorApiMapper.MapToApiModel(result);

            SingleResult<AuthorApiViewModel> response =
                new SingleResult<AuthorApiViewModel>(viewModel);

            return Ok(response);
        }
    }
}
