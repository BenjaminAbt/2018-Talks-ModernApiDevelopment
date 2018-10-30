using System.Reflection;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Abstractions;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories;
using BenjaminAbt.ModernAPIDevelopment.Common.Database.Repositories.InMemory;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.ModernAPIDevelopment.CommonAspNetCore.Middlewares
{
    public static class EngineMiddlewareExtensions
    {
        public static IServiceCollection AddCommonEngine(this IServiceCollection services)
        {
            // Database
            services.AddSingleton<IDataContext>(_ => new InMemoryDataContext(
                authorsCount: 25, booksCount: 200, booksPerAuthorMin: 3, booksPerAuthorMax: 12));

            services.AddTransient<IAuthorsRepository, AuthorsInMemoryRepository>();
            services.AddTransient<IBooksRepository, BooksInMemoryRepository>();
            // MediatR Engine

            Assembly engineAssembly = typeof(CommonEngine).Assembly;

            services.AddMediatR(engineAssembly);

            return services;
        }
    }
}
