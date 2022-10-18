using Stocks.Api.Common.Contracts;
using System.Collections.Generic;

namespace Stocks.Cache
{
    public interface IDataCache
    {
        Dictionary<string, StockInformation> StockInformation { get; }

        Dictionary<string, MarketInformation> MarketInformation { get; }
    }
}
