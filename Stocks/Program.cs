using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Stocks.Cache.Bootstrap;
using Stocks.Controllers._Internal.IEXCloud.Bootstrap;

namespace Stocks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var hostingEnvironment = (IWebHostEnvironment)host.Services.GetService(typeof(IWebHostEnvironment));

            host
                .BuildDataFiles(hostingEnvironment.ContentRootPath)
                .LoadCache(hostingEnvironment.ContentRootPath)
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
