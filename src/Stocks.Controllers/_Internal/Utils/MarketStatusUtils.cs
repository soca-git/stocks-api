using Stocks.Api.Status.Market.Contracts;
using System;

namespace Stocks.Controllers._Internal.Utils
{
    internal static class MarketStatusUtils
    {
        public static MarketStatus CalculateMarketStatus(decimal openTime, decimal closeTime)
        {
            var current = MillisecondsSinceEpochNow();

            if (current > openTime && current < closeTime)
            {
                return MarketStatus.Open;
            }

            return MarketStatus.Closed;
        }

        private static decimal MillisecondsSinceEpochNow()
        {
            var timeSpanSinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return (decimal)timeSpanSinceEpoch.TotalMilliseconds;
        }
    }
}
