using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleJsonApi.Controllers
{
    [Route("authors")]
    [ApiController] // https://docs.microsoft.com/de-de/aspnet/core/web-api/?view=aspnetcore-2.1
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAll()
        {
            IList<Author> result = await _mediator.Send(new GetAllAuthorsQuery());

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(Guid id)
        {
            Author result = await _mediator.Send(new GetAuthorByIdQuery(id));

            if (result is null)
            {
                return NotFound(id);
            }

            return Ok(result);
        }
    }
}
