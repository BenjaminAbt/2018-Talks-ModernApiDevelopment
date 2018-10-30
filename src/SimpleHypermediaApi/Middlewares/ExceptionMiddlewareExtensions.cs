using Microsoft.AspNetCore.Builder;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Middlewares
{
    /// <summary>
    /// Extensions for general middleswares to handle exceptions
    /// </summary>
    public static class GeneralExceptionsMiddlewareExtensions
    {
        /// <summary>
        /// Registeres general middleswares to handle exceptions to the application middleware handler
        /// </summary>
        public static IApplicationBuilder UseGeneralExceptionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseInternalServiceErrorExceptionMiddleware();

            return builder;

        }
    }
}