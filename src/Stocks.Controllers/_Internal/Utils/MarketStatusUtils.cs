using Stocks.Api.Status.Market.Contracts;

namespace Stocks.Controllers._Internal.Utils
{
    internal static class MarketStatusUtils
    {
        public static MarketStatus CalculateMarketStatus(string latestSource)
        {
            if (latestSource.ToLower() == "close")
            {
                return MarketStatus.Closed;
            }

            return MarketStatus.Open;
        }
    }
}
