using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Middlewares
{
    public static class GraphQlMiddlewareExtensions
    {
        public static IServiceCollection AddGraphQl(this IServiceCollection services,
            Action<GraphQlMiddleware.Options> options)
        {
            GraphQlMiddleware.Options opt = new GraphQlMiddleware.Options();
            options.Invoke(opt);
            services.AddSingleton(opt);

            return services;
        }
  

        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GraphQlMiddleware>();
        }
    }
}