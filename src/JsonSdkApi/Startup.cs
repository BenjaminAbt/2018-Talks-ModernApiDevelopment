using BenjaminAbt.ModernAPIDevelopment.CommonAspNetCore.Middlewares;
using BenjaminAbt.ModernAPIDevelopment.JsonSdkApi.Binders.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.ModernAPIDevelopment.JsonSdkApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCommonEngine();

            services.AddCors(options =>
            {
                // https://de.wikipedia.org/wiki/Cross-Origin_Resource_Sharing
                // https://docs.microsoft.com/de-de/aspnet/core/security/cors?view=aspnetcore-2.1
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials());
            });

            services.AddMvc(options =>
            { 
                // Output

                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                options.RespectBrowserAcceptHeader = true; // false by default
                //                                           // or   .AddXmlSerializerFormatters();


                // Model Binder
                options.ModelBinderProviders.Insert(0, new AuthorModelBinderProvider());
            })
           .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
