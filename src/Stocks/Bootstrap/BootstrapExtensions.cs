using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Cache;
using Stocks.Errors;

namespace Stocks.Bootstrap
{
    public static class BootstrapExtensions
    {
        public static IServiceCollection RegisterAdditionalServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddSingleton<IDataCache>(new DataCache(env.ContentRootPath));
            services.AddTransient<ProblemDetailsFactory, StocksProblemDetailsFactory>();

            return services;
        }
    }
}
