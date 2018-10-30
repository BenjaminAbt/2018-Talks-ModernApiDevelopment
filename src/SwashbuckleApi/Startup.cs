using BenjaminAbt.ModernAPIDevelopment.CommonAspNetCore.Middlewares;
using BenjaminAbt.ModernAPIDevelopment.SwashbuckleApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;


namespace BenjaminAbt.ModernAPIDevelopment.SwashbuckleApi
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

            IConfigurationSection swaggerSection = Configuration.GetSection("Swagger");
            services.Configure<SwaggerConfiguration>(swaggerSection);
            SwaggerConfiguration swagger = swaggerSection.Get<SwaggerConfiguration>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swagger.ApiVersion, new Info
                {
                    Title = swagger.Title,
                    Version = swagger.ApiVersion,
                    Contact = new Contact
                    {
                        Name = swagger.ContactName,
                        Email = swagger.ContactMail,
                        Url = swagger.ContactUrl
                    },
                    Description = swagger.Description,
                    License = new License
                    {
                        Name = swagger.LicenseName,
                        Url = swagger.LicenseUrl
                    },
                    TermsOfService = swagger.TermsOfService
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        /// <summary>
        /// Description
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<SwaggerConfiguration> swaggerOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            SwaggerConfiguration swagger = swaggerOptions.Value;
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{swagger.ApiVersion}/swagger.json", swagger.Title);
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
