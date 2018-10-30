using Microsoft.AspNetCore.Builder;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Middlewares
{
    /// <summary>
    /// Extensions for <see cref="InternalServiceErrorExceptionMiddleware"/>
    /// </summary>
    public static class CustomErrorExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Registeres <see cref="InternalServiceErrorExceptionMiddleware"/> to the application middleware handler
        /// </summary>
        public static IApplicationBuilder UseCustomErrorExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomErrorExceptionMiddleware>();
        }
    }
}