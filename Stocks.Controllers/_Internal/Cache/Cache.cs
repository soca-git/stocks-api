using Stocks.Api.Common.Contracts;
using System.Collections.Generic;

namespace Stocks.Controllers._Internal.Cache
{
    internal static class Cache
    {
        public static Dictionary<string, StockBasicInformation> StockBasicInformation { get; set; }
    }
}
