using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleJsonApi.Controllers
{
    [Route("books")]
    [ApiController] // https://docs.microsoft.com/de-de/aspnet/core/web-api/?view=aspnetcore-2.1
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            IList<Book> result = await _mediator.Send(new GetAllBooksQuery());

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(Guid id)
        {
            Book result = await _mediator.Send(new GetBookByIdQuery(id));

            if (result is null)
            {
                return NotFound(id);
            }

            return Ok(result);
        }
    }
}
