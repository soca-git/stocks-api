using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Stocks.Controllers._Internal.Mappers;
using System.IO;

namespace Stocks.Controllers._Internal.IEXCloud.Bootstrap
{
    /// <summary>
    /// </summary>
    public static class BootstrapExtensions
    {
        /// <summary>
        /// Build data files if they don't already exist.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="contentRootPath"></param>
        /// <returns></returns>
        public static IApplicationBuilder BuildDataFiles(this IApplicationBuilder app, string contentRootPath)
        {
            var client = new IEXClient();
            string dataPath = $"{contentRootPath}\\..\\Data";

            if (!File.Exists($"{dataPath}\\stock-information.json"))
            {
                var stockInformationHash = client.Api.ReferenceData.SymbolsAsync().ContinueWith(x => x.Result.Data.ToStockInformationHash()).Result;

                var jsonData = JsonConvert.SerializeObject(stockInformationHash);
                File.WriteAllText($"{dataPath}\\stock-information.json", JsonConvert.SerializeObject(stockInformationHash));
                File.WriteAllText($"{dataPath}\\ticker-symbols.json", JsonConvert.SerializeObject(stockInformationHash.Keys));
            }

            return app;
        }
    }
}
