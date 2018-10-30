using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Commands.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.JsonSdkApi.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorApiViewModel>>> Get()
        {
            IList<Author> result = await _mediator.Send(new GetAllAuthorsQuery());

            IEnumerable<AuthorApiViewModel> viewModels = result.Select(AuthorApiMapper.MapToApiModel);
            return Ok(viewModels);
        }

        //[HttpGet("{id}", Name = "GetAuthorById")]
        //public async Task<ActionResult<AuthorApiViewModel>> Get(Guid id)
        //{
        //    // Request
        //    Author result = await _mediator.Send(new GetAuthorByIdQuery(id));

        //    if (result is null)
        //    {
        //        return NotFound(id);
        //    }

        //    // Mapping
        //    AuthorApiViewModel viewModel = AuthorApiMapper.MapToApiModel(result);
        //    return Ok(viewModel);
        //}

        [HttpPost]
        public async Task<ActionResult<AuthorApiViewModel>> Add(AuthorAddModel addModel)
        {
            Author result = await _mediator.Send(new AddAuthorCommand(addModel.Name, addModel.LastName, addModel.DateOfBirth));

            AuthorApiViewModel viewModel = AuthorApiMapper.MapToApiModel(result);

            return Created(Url.RouteUrl("GetAuthorById", new { id = viewModel.Id }), viewModel);
        }
    }
}
