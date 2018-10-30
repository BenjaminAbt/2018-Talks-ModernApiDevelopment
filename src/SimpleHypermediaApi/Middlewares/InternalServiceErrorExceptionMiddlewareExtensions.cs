using Microsoft.AspNetCore.Builder;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Middlewares
{
    /// <summary>
    /// Extensions for <see cref="InternalServiceErrorExceptionMiddleware"/>
    /// </summary>
    public static class InternalServiceErrorExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Registeres <see cref="InternalServiceErrorExceptionMiddleware"/> to the application middleware handler
        /// </summary>
        public static IApplicationBuilder UseInternalServiceErrorExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InternalServiceErrorExceptionMiddleware>();
        }
    }
}