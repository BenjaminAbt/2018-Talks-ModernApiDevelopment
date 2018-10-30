﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BenjaminAbt.ModernAPIDevelopment.ODataApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
                .UseStartup<Startup>();
    }
}
