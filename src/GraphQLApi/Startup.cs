using BenjaminAbt.ModernAPIDevelopment.CommonAspNetCore.Middlewares;
using BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Engine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Middlewares;
using GraphQL.Types;

namespace BenjaminAbt.ModernAPIDevelopment.GraphQLApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCommonEngine();

            services.AddScoped<IObjectGraphType, MyGraphQuerySchema>();
            services.AddScoped<ISchema, MyQuerySchema>();

            services.AddGraphQl(o => o.Path = "/graph"); // access graph via /graph

            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL();

            // app.UseGraphiQl(); // uncomment this line if you want to use the embedded GraphQL UI explorer
            app.UseMvc();
        }
    }
}
