﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Cache;
using Stocks.Errors;

namespace Stocks.Bootstrap
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetCorsPolicy(this IServiceCollection services, string policyName, string[] originUrls)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: policyName,
                    builder =>
                    {
                        builder.WithOrigins(originUrls)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            return services;
        }

        public static IServiceCollection RegisterAdditionalServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddSingleton<IDataCache>(new DataCache(env.ContentRootPath));
            services.AddTransient<ProblemDetailsFactory, StocksProblemDetailsFactory>();

            return services;
        }
    }
}
