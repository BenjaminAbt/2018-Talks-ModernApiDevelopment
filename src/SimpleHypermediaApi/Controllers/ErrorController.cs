using System.Collections.Generic;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models;
using BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Controllers
{
    /// <summary>
    /// Error Controller
    /// </summary>
    [Route("error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Custom()
        {
            throw new CustomErrorException();
        }

    }
}
