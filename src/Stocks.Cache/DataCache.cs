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

            var jsonData = System.IO.File.ReadAllText($"{dataPath}\\stock-information.json");
            StockInformation = JsonConvert.DeserializeObject<Dictionary<string, StockInformation>>(jsonData);
        }

        public Dictionary<string, StockInformation> StockInformation { get; private set; }
    }
}
