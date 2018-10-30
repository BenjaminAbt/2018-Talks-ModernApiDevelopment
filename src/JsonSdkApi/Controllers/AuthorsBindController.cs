using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.JsonSdkApi.Controllers
{
    [Route("authors")]
    [ApiController]
    public class AuthorsBindController : ControllerBase
    {
        [HttpGet("{id}", Name = "GetAuthorById")]
        public async Task<ActionResult<AuthorApiViewModel>> Get(
                [ModelBinder(Name = "id")]Author author)
        // you have to use ModelBinder here because the default behavior gets
        //    overwritten by the ApiController
        {
            if (author is null)
            {
                return NotFound();
            }

            // Mapping
            AuthorApiViewModel viewModel = AuthorApiMapper.MapToApiModel(author);
            return Ok(await Task.FromResult(viewModel));
        }
    }
}
