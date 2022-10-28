using Stocks.Api.Status.Market.Contracts;
using Stocks.Shared.Utils;
using System;

namespace Stocks.Controllers._Internal.Utils
{
    internal static class MarketStatusUtils
    {
        public static MarketStatus CalculateMarketStatus(decimal latestUpdate)
        {
            // Allow 1 min for latency given a 15min delay update
            var current = DateTimeUtils.MillisecondsSinceEpoch(DateTime.UtcNow.AddMinutes(-16));

            if (latestUpdate > current)
            {
                return MarketStatus.Open;
            }

            return MarketStatus.Closed;
        }
    }
}
