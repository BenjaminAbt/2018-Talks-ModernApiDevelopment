using System;
using System.Net;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Exceptions;
using BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Middlewares
{


    /// <summary>
    /// Middleware to handle <see cref="CustomErrorException"/> exceptions
    /// </summary>
    public class CustomErrorExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomErrorExceptionMiddleware> _logger;

        /// <summary>
        /// Creates a new instance of <see cref="InternalServiceErrorExceptionMiddleware"/>
        /// </summary>
        public CustomErrorExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<CustomErrorExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
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
            catch (CustomErrorException ex)
            {
                if (!context.Response.HasStarted)
                {
                    int errorCode = (int)HttpStatusCode.InternalServerError;

                    CustomErrorResultModel result = new CustomErrorResultModel
                    {
                        Timestamp = ex.Timestamp
                    };

                    context.Response.Clear();
                    context.Response.StatusCode = errorCode;
                    context.Response.ContentType = "application/json";

                    DetailedErrorResult<CustomErrorResultModel> error = new DetailedErrorResult<CustomErrorResultModel>(result, errorCode, "Unexpected internal error", "Oops");
                    await context.Response.WriteAsync(error.ToJson());
                }
            }
        }

        public class CustomErrorResultModel
        {
            public DateTime Timestamp { get; set; }
        }
    }
}
