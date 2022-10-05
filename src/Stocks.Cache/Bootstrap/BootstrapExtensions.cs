using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Stocks.Api.Common.Contracts;
using System.Collections.Generic;

namespace Stocks.Cache.Bootstrap
{
    /// <summary>
    /// </summary>
    public static class BootstrapExtensions
    {
        /// <summary>
        /// Load data into cache.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="contentRootPath"></param>
        /// <returns></returns>
        public static IApplicationBuilder LoadCache(this IApplicationBuilder app, string contentRootPath)
        {
            string dataPath = $"{contentRootPath}\\..\\Data";

            var jsonData = System.IO.File.ReadAllText($"{dataPath}\\stock-information.json");
            DataCache.StockBasicInformation = JsonConvert.DeserializeObject<Dictionary<string, StockInformation>>(jsonData);

            return app;
        }
    }
}
