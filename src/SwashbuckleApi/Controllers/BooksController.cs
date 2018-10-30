using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Commands.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.SwashbuckleApi.Controllers
{
    /// <summary>
    /// Books Controller
    /// </summary>
    [Route("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Books Controller
        /// </summary>
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns all books
        /// </summary>
        /// <response code="200">Returns all books from the database</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookApiViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BookApiViewModel>>> Get()
        {
            IList<Book> result = await _mediator.Send(new GetAllBooksQuery());

            IEnumerable<BookApiViewModel> viewModels = result.Select(BooksApiMapper.MapToApiModel);
            return Ok(viewModels);
        }

        /// <summary>
        /// Gets a specific <see cref="BookApiViewModel"/> from given <paramref name="id"/>
        /// </summary>
        /// <param name="id">Unique ID of the book you're looking for</param>
        /// <returns>A </returns>
        /// <response code="200">The <see cref="BookApiViewModel"/> of given <paramref name="id"/></response>
        /// <response code="404">No book found</response>         
        [HttpGet("{id}", Name = "GetBookById")]
        [ProducesResponseType(typeof(BookApiViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<BookApiViewModel>> Get(Guid id)
        {
            Book result = await _mediator.Send(new GetBookByIdQuery(id));

            if (result is null)
            {
                return NotFound(id);
            }

            BookApiViewModel viewModel = BooksApiMapper.MapToApiModel(result);
            return Ok(viewModel);
        }


        /// <summary>
        /// Adds a book
        /// </summary>
        /// <param name="addModel">Model to add</param>
        /// <returns>Added book</returns>
        [ProducesResponseType(typeof(BookApiViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<ActionResult<BookApiViewModel>> Add(BookAddModel addModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book result = await _mediator.Send(new AddBookCommand(addModel.Name, (double)addModel.Price));
            if (result is null)
            {
                return BadRequest();
            }

            BookApiViewModel viewModel = BooksApiMapper.MapToApiModel(result);
            return Created(Url.RouteUrl("GetBookById", new { id = viewModel.Id }), viewModel);
        }
    }
}
