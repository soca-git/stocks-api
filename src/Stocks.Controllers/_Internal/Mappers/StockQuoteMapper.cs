using IEXSharp.Model;
using IEXSharp.Model.Shared.Response;
using Stocks.Api.Prices.Quote.Contracts;
using Stocks.Cache;
using Stocks.Controllers._Internal.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class StockQuoteMapper
    {
        public static List<StockQuote> ToStockQuotes(this IEXResponse<Quote>[] quotes, IDataCache cache)
        {
            if (!quotes.IsDataPresent())
            {
                return new List<StockQuote>();
            }

            return quotes
                .Select(response => response.ToStockQuote(cache))
                .ToList();
        }

        public static StockQuote ToStockQuote(this IEXResponse<Quote> quote, IDataCache cache)
        {
            if (!quote.IsDataPresent())
            {
                return null;
            }

            return new StockQuote
            {
                TickerSymbol = quote.Data.symbol,
                Name = quote.Data.companyName,
                Currency = cache.StockInformation[quote.Data.symbol].Currency,
                Market = cache.StockInformation[quote.Data.symbol].Market,
                CurrentPrice = quote.Data.latestPrice ?? 0,
                CurrentDelta = quote.Data.change ?? 0
            };
        }
    }
}
