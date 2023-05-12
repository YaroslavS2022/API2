using API2.Models;
using Microsoft.AspNetCore.Hosting;
using System.Web.Http;

namespace API2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create the host builder
            var hostBuilder = CreateHostBuilder(args);

            // Build and run the host
            hostBuilder.Build().Run();

        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

}
