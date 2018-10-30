using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Commands.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.JsonSdkApi.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookApiViewModel>>> Get()
        {
            IList<Book> result = await _mediator.Send(new GetAllBooksQuery());

            IEnumerable<BookApiViewModel> viewModels = result.Select(BooksApiMapper.MapToApiModel);
            return Ok(viewModels);
        }

        [HttpGet("{id}", Name = "GetBookById")]
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
