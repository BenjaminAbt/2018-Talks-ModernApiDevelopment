using System;
using System.Net;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Middlewares
{
    /// <summary>
    /// Middleware to handle all exceptions
    /// </summary>
    public class InternalServiceErrorExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<InternalServiceErrorExceptionMiddleware> _logger;

        /// <summary>
        /// Creates a new instance of <see cref="InternalServiceErrorExceptionMiddleware"/>
        /// </summary>
        public InternalServiceErrorExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<InternalServiceErrorExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        /// <summary>
        /// Invokes the next middleware of the current request hontext
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (!context.Response.HasStarted)
                {
                    int errorCode = (int)HttpStatusCode.InternalServerError;

                    context.Response.Clear();
                    context.Response.StatusCode = errorCode;
                    context.Response.ContentType = "application/json";

                    ErrorResult error = new ErrorResult(errorCode, "Unexpected internal error", ex.GetType().Name);
                    await context.Response.WriteAsync(error.ToJson());
                }
            }
        }
    }
}
