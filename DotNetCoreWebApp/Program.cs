using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp
{
    public class Program
    {
        static string env = "";

        public static void Main(string[] args)
        {
            try
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                env = config.GetSection("Env").Value;
                var configuration = new ConfigurationBuilder()
               .AddCommandLine(args)
               .Build();

                var host = new WebHostBuilder()
                     .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseConfiguration(configuration)
                    .ConfigureAppConfiguration((context, config) =>
                    {
                        
                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: true);
                    })
                    .UseIISIntegration()
                    .UseIIS()
                    .UseStartup<Startup>()
                    .Build();
                host.Run();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((a, config) =>
                {
                    config.AddJsonFile("appsettings.json");
                    config.AddJsonFile($"appsettings.{env}.json");
                })
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });

    }
}
