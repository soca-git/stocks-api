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

            return new MarketStatusPreview
            {
                Name = cache.MarketInformation[quote.Data.symbol].Name,
                Status = MarketStatusUtils.CalculateMarketStatus(quote.Data.latestSource)
            };
        }
    }
}
