using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Stocks.Controllers._Internal.Mappers;
using System.IO;

namespace Stocks.Controllers._Internal.IEXCloud.Bootstrap
{
    public static class BootstrapExtensions
    {
        /// <summary>
        /// Build data files if they don't already exist.
        /// </summary>
        /// <param name="host"></param>
        public static void BuildDataFiles(this IHost host)
        {
            var client = new IEXClient();
            var hostingEnvironment = (IHostingEnvironment) host.Services.GetService(typeof(IHostingEnvironment));
            string dataPath = $"{hostingEnvironment.ContentRootPath}\\..\\Data";

            if (!File.Exists($"{dataPath}\\stock-information.json"))
            {
                var stockBasicInfoHash = client.Api.ReferenceData.SymbolsAsync().ContinueWith(x => x.Result.Data.ToStockBasicInformationHash()).Result;

                var jsonData = JsonConvert.SerializeObject(stockBasicInfoHash);
                File.WriteAllText($"{dataPath}\\stock-information.json", JsonConvert.SerializeObject(stockBasicInfoHash));
                File.WriteAllText($"{dataPath}\\ticker-symbols.json", JsonConvert.SerializeObject(stockBasicInfoHash.Keys));
            }
        }
    }
}
