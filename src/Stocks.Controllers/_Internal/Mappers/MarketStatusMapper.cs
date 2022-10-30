using IEXSharp.Model;
using IEXSharp.Model.Shared.Response;
using Stocks.Api.Status.Market.Contracts;
using Stocks.Cache;
using Stocks.Controllers._Internal.Extensions;
using Stocks.Controllers._Internal.Utils;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class MarketStatusMapper
    {
        public static MarketStatusPreview ToMarketStatus(this IEXResponse<Quote> quote, IDataCache cache)
        {
            if (!quote.IsDataPresent())
            {
                return null;
            }

            var market = cache.StockInformation[quote.Data.symbol].Market;

            return new MarketStatusPreview
            {
                Name = cache.MarketInformation[market].Name,
                Status = MarketStatusUtils.CalculateMarketStatus(quote.Data.latestSource)
            };
        }
    }
}
