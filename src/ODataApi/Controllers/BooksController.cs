using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.ODataApi.Controllers
{
    public class BooksController : ODataController
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [EnableQuery]
        public async Task<ActionResult<IEnumerable<BookApiViewModel>>> GetBooks()
        {
            IList<Book> result = await _mediator.Send(new GetAllBooksQuery());

            IEnumerable<BookApiViewModel> viewModels = result.Select(BooksApiMapper.MapToApiModel);
            return Ok(viewModels);
        }

        [EnableQuery]
        public async Task<ActionResult<BookApiViewModel>> GetBook([FromODataUri]Guid key)
        {
            Book result = await _mediator.Send(new GetBookByIdQuery(key));

            if (result is null)
            {
                return NotFound(key);
            }

            BookApiViewModel viewModel = BooksApiMapper.MapToApiModel(result);
            return Ok(viewModel);
        }

    }
}
