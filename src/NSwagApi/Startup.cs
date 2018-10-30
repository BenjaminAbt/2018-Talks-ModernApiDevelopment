using System.Reflection;
using BenjaminAbt.ModernAPIDevelopment.CommonAspNetCore.Middlewares;
using BenjaminAbt.ModernAPIDevelopment.NSwagApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NSwag.AspNetCore;

namespace BenjaminAbt.ModernAPIDevelopment.NSwagApi
{
    /// <summary>
    /// Description
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Description
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Description
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Description
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCommonEngine();

            services.AddOptions();
            services.Configure<SwaggerOptions>(Configuration.GetSection("Swagger"));

            // https://docs.microsoft.com/en-us/aspnet/core/mvc/compatibility-version?view=aspnetcore-2.1
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        /// <summary>
        /// Description
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<SwaggerOptions> swaggerOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();

            SwaggerOptions swagger = swaggerOptions.Value;
            // Enable the Swagger UI middleware and the Swagger generator
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Version = swagger.ApiVersion;
                    document.Info.Title = swagger.Title;
                    document.Info.Description = swagger.Description;
                    document.Info.TermsOfService = swagger.TermsOfService;
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = swagger.ContactName,
                        Email = swagger.ContactMail,
                        Url = swagger.ContactUrl
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = swagger.LicenseName,
                        Url = swagger.LicenseUrl
                    };
                };
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
