using IEXSharp.Model;
using IEXSharp.Model.Shared.Response;
using Stocks.Api.Prices.AdvancedQuote.Contracts;
using Stocks.Cache;
using Stocks.Controllers._Internal.Extensions;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class StockAdvancedQuoteMapper
    {
        public static StockAdvancedQuote ToStockAdvancedQuote(this IEXResponse<Quote> quote, IDataCache cache)
        {
            if (!quote.IsDataPresent())
            {
                return null;
            }

            return new StockAdvancedQuote
            {
                TickerSymbol = quote.Data.symbol,
                Name = quote.Data.companyName,
                Currency = cache.StockInformation[quote.Data.symbol].Currency,
                Market = cache.StockInformation[quote.Data.symbol].Market,
                CurrentPrice = quote.Data.latestPrice ?? 0,
                CurrentDelta = quote.Data.change ?? 0,
                OpenPrice = quote.Data.iexOpen,
                ClosePrice = quote.Data.iexClose,
                HighPrice = quote.Data.high,
                LowPrice = quote.Data.low,
                Volume = quote.Data.iexVolume,
                AverageVolume = quote.Data.avgTotalVolume,
                PricePerEarningsRatio = quote.Data.peRatio,
                MarketCap = quote.Data.marketCap,
                FiftyTwoWeekHigh = quote.Data.week52High,
                FiftyTwoWeekLow = quote.Data.week52Low,

                // TODO
                Yield = null,
                Beta = null,
                EarningsPerShare = null
            };
        }
    }
}
