using BenjaminAbt.ModernAPIDevelopment.CommonAspNetCore.Middlewares;
using BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Engine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using GraphiQl;
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

            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseGraphiQl();
            }
            app.UseMvc();
        }
    }
}
