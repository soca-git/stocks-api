using Newtonsoft.Json;
using Stocks.Api.Common.Contracts;
using System.Collections.Generic;

namespace Stocks.Cache
{
    public class DataCache : IDataCache
    {
        public DataCache(string contentRootPath)
        {
            string dataPath = $"{contentRootPath}\\..\\Data";

            LoadStockInformation(dataPath);
            LoadMarketInformation(dataPath);
        }

        public Dictionary<string, StockInformation> StockInformation { get; private set; }

        public Dictionary<string, MarketInformation> MarketInformation { get; private set; }

        private void LoadStockInformation(string dataPath)
        {
            var jsonData = System.IO.File.ReadAllText($"{dataPath}\\stock-information.json");
            StockInformation = JsonConvert.DeserializeObject<Dictionary<string, StockInformation>>(jsonData);
        }

        private void LoadMarketInformation(string dataPath)
        {
            var jsonData = System.IO.File.ReadAllText($"{dataPath}\\market-information.json");
            MarketInformation = JsonConvert.DeserializeObject<Dictionary<string, MarketInformation>>(jsonData);
        }
    }
}
