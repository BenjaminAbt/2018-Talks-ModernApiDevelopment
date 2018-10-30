using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace BenjaminAbt.ModernAPIDevelopment.CommonAspNetCore
{
    public static class BuildHost
    {
        public static IWebHostBuilder UseAppHostOptions(this IWebHostBuilder webHost)
        {
            return webHost
                    .ConfigureAppConfiguration((builderContext, config) =>
                    {
                        IHostingEnvironment env = builderContext.HostingEnvironment;

                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // default file
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true) // environment file for local development
                            .AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true) // environment file machine name
                            .AddEnvironmentVariables(); // Docker environment support

                    })
                    // Logging
                    .UseSerilog()
                    // Register Error Handling
                    .UseSetting("detailedErrors", "true")
                    .CaptureStartupErrors(true)
                // - End
                ;

        }


        public static void UseAppExecuter(this IWebHostBuilder webHost)
        {

            // TODO: Not Hard coded
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Building Webhost");

                IWebHost host = webHost.Build();

                Log.Information("Starting Webhost");

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
