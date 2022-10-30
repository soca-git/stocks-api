using Stocks.Api.Prices.Quote.Contracts;
using Stocks.Api.Search.Stocks.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class StockPreviewMapper
    {
        public static List<StockPreview> ToStockPreviews(this List<StockQuote> quotes)
        {
            return quotes.Select(quote => quote.ToStockPreview()).ToList();
        }

        private static StockPreview ToStockPreview(this StockQuote quote)
        {
            return new StockPreview
            {
                TickerSymbol = quote.TickerSymbol,
                Name = quote.Name,
                Market = quote.Market,
                Currency = quote.Currency,
                CurrentPrice = quote.CurrentPrice,
                CurrentDelta = quote.CurrentDelta
            };
        }
    }
}
