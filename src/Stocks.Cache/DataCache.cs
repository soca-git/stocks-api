using Stocks.Api.Common.Contracts;
using System.Collections.Generic;

namespace Stocks.Cache
{
    public static class DataCache
    {
        public static Dictionary<string, StockInformation> StockInformation { get; set; }
    }
}
