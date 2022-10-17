using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Cache;

namespace Stocks.Bootstrap
{
    public static class BootstrapExtensions
    {
        public static IServiceCollection RegisterAdditionalServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddSingleton<IDataCache>(new DataCache(env.ContentRootPath));

            return services;
        }
    }
}
