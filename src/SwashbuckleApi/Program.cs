using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BenjaminAbt.ModernAPIDevelopment.SwashbuckleApi
{
    /// <summary>
    /// Description
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Description
        /// </summary>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Description
        /// </summary>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
