using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using BenjaminAbt.ModernAPIDevelopment.JsonSdkApi.Binders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.JsonSdkApi.Controllers
{
    [Route("authors")]
    [ApiController]
    public class AuthorsIdBindController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsIdBindController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("{id}", Name = "GetAuthorById")]
        //public async Task<ActionResult<AuthorApiViewModel>> Get(
        //        [ModelBinder(Name = "id")]AuthorId author)
        //// you have to use ModelBinder here because the default behavior gets
        ////    overwritten by the ApiController
        //{
        //    // Validation
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // Request
        //    Author result = await _mediator.Send(new GetAuthorByIdQuery(author.Id));
        //    if (result is null)
        //    {
        //        return NotFound();
        //    }

        //    // Mapping
        //    AuthorApiViewModel viewModel = AuthorApiMapper.MapToApiModel(result);
        //    return Ok(await Task.FromResult(viewModel));
        //}
    }
}
