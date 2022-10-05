using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Stocks.Controllers._Internal.IEXCloud.Bootstrap;

namespace Stocks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.BuildDataFiles();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
