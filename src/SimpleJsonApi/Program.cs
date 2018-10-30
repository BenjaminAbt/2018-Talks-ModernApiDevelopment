using System.IO;
using BenjaminAbt.ModernAPIDevelopment.CommonAspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleJsonApi
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {

                WebHost.CreateDefaultBuilder(args)
                    // Content related directory
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    // Build Host
                    .UseAppHostOptions()
                    // Startup
                    .UseStartup<Startup>()
                    // Build Host
                    .UseAppExecuter();

                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
}

