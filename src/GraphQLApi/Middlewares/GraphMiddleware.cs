using System.IO;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Extensions;
using GraphQL;
using GraphQL.Types;
using MediatR;
using Microsoft.AspNetCore.Http;
using static System.String;

namespace BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Middlewares
{
    public class GraphQlMiddleware
    {
        public class Options
        {
            public string Path { get; set; } = "/graph"; // default
        }

        private readonly RequestDelegate _next;

        public GraphQlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IMediator mediator, ISchema schema, Options graphOptions)
        {
            if (!httpContext.Request.Path.StartsWithSegments(graphOptions.Path))
            {
                // next middleware if path does not match
                await _next(httpContext);
            }
            else
            {
                // execute GraphQL
                using (StreamReader sr = new StreamReader(httpContext.Request.Body))
                {
                    string query = await sr.ReadToEndAsync();

                    if (!IsNullOrWhiteSpace(query))
                    {
                        ExecutionResult result = await new DocumentExecuter()
                            .ExecuteAsync(options =>
                            {
                                options.Schema = schema;
                                options.Query = query;
                            })
                            .ConfigureAwait(false);

                        result.ThrowOnError();
                        await httpContext.WriteResultAsync(result);
                    }
                }
            }
        }
    }
}
