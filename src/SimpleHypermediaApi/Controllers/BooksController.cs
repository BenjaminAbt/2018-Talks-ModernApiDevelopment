using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Results.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Models;
using BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Controllers
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

        [HttpGet("", Name = "GetAllBooks")]
        [ProducesResponseType(typeof(IEnumerable<BookApiViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BookApiViewModel>>> GetMany(int skip = 0, int take = 3)
        {
            GetManyBooksQueryResult result = await _mediator.Send(new GetManyBooksQuery(skip, take));

            List<BookApiHypermediaViewModel> viewModels = result.Books.AsEnumerable()
                .Select(BooksApiMapper.MapToApiModel)
                .Select(item => new BookApiHypermediaViewModel(item,
                    Url.RouteUrl("GetBookById", new { id = item.Id })))
                .ToList();

            CollectionResult<BookApiHypermediaViewModel> response =
                new CollectionResult<BookApiHypermediaViewModel>(viewModels, skip, take, result.TotalCount);

            return Ok(response);
        }

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

            SingleResult<BookApiViewModel> response =
                new SingleResult<BookApiViewModel>(viewModel);

            return Ok(response);
        }
    }
}
