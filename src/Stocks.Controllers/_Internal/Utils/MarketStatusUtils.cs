using Stocks.Api.Status.Market.Contracts;
using Stocks.Shared.Utils;
using System;

namespace Stocks.Controllers._Internal.Utils
{
    internal static class MarketStatusUtils
    {
        public static MarketStatus CalculateMarketStatus(decimal openTime, decimal closeTime)
        {
            var current = DateTimeUtils.MillisecondsSinceEpoch(DateTime.UtcNow.AddSeconds(-30));

            if (current > openTime && current < closeTime)
            {
                return MarketStatus.Open;
            }

            return MarketStatus.Closed;
        }
    }
}
