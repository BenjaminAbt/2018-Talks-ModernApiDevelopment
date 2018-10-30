using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using Microsoft.AspNetCore.Http;

namespace BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Extensions
{
    public static class ExecutionExtensions
    {
        public static async Task WriteResultAsync(this HttpContext httpContext, ExecutionResult executionResult)
        {
            string jsonBody = new DocumentWriter(true).Write(executionResult);

            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(jsonBody);
        }

        public static void ThrowOnError(this ExecutionResult executionResult)
        {
            if (executionResult.Errors?.Count > 0)
            {
                List<Exception> errors = new List<Exception>();
                foreach (ExecutionError error in executionResult.Errors)
                {
                    Exception e = new Exception(error.Message);
                    if (error.InnerException != null)
                    {
                        e = new Exception(error.Message, error.InnerException);
                    }
                    errors.Add(e);
                }
                throw new AggregateException(errors);
            }
        }
    }
}