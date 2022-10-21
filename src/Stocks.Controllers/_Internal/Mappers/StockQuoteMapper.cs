using IEXSharp.Model;
using IEXSharp.Model.Shared.Response;
using Stocks.Api.Prices.Quote.Contracts;
using Stocks.Cache;
using System.Collections.Generic;
using System.Linq;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class StockQuoteMapper
    {
        public static List<StockQuote> ToStockQuotes(this IEXResponse<Quote>[] source, IDataCache cache)
        {
            return source
                .Select(response => response.Data.ToStockQuote(cache))
                .ToList();
        }

        public static StockQuote ToStockQuote(this Quote quote, IDataCache cache)
        {
            return new StockQuote
            {
                TickerSymbol = quote.symbol,
                Name = quote.companyName,
                Currency = cache.StockInformation[quote.symbol].Currency,
                Market = cache.StockInformation[quote.symbol].Market,
                CurrentPrice = quote.latestPrice ?? 0,
                CurrentDelta = quote.change ?? 0
            };
        }
    }
}
