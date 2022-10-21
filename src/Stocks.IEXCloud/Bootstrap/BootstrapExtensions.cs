using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Stocks.IEXCloud.Mappers;
using System.IO;

namespace Stocks.IEXCloud.Bootstrap
{
    /// <summary>
    /// </summary>
    public static class BootstrapExtensions
    {
        /// <summary>
        /// Register the IEXClient component.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterIEXClient(this IServiceCollection services)
        {
            services.AddTransient<IIEXClient, IEXClient>();

            return services;
        }

        /// <summary>
        /// Build data files if they don't already exist.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="contentRootPath"></param>
        /// <returns></returns>
        public static IMvcBuilder BuildDataFiles(this IMvcBuilder builder, string contentRootPath)
        {
            var client = new IEXClient();
            string dataPath = $"{contentRootPath}\\..\\Data";

            if (!File.Exists($"{dataPath}\\stock-information.json"))
            {
                WriteStockInformation(client, dataPath);
            }

            if (!File.Exists($"{dataPath}\\market-information.json"))
            {
                WriteMarketInformation(client, dataPath);
            }

            return builder;
        }

        private static void WriteStockInformation(IEXClient client, string dataPath)
        {
            var stockInformationHash = client.Api.ReferenceData.SymbolsAsync().ContinueWith(x => x.Result.Data.ToStockInformationHash()).Result;
            var jsonData = JsonConvert.SerializeObject(stockInformationHash);

            File.WriteAllText($"{dataPath}\\stock-information.json", JsonConvert.SerializeObject(stockInformationHash));
            File.WriteAllText($"{dataPath}\\ticker-symbols.json", JsonConvert.SerializeObject(stockInformationHash.Keys));
        }

        private static void WriteMarketInformation(IEXClient client, string dataPath)
        {
            var marketInformationHash = client.Api.ReferenceData.ExchangeInternationalAsync().ContinueWith(x => x.Result.Data.ToMarketInformationHash()).Result;
            var jsonData = JsonConvert.SerializeObject(marketInformationHash);

            File.WriteAllText($"{dataPath}\\market-information.json", JsonConvert.SerializeObject(marketInformationHash));
            File.WriteAllText($"{dataPath}\\market-names.json", JsonConvert.SerializeObject(marketInformationHash.Keys));
        }
    }
}
