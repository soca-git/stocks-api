using IEXSharp.Model;
using IEXSharp.Model.CoreData.StockPrices.Response;
using Stocks.Api.Prices.Historical.Contracts;
using Stocks.Controllers._Internal.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class HistoricalStockPricesMapper
    {
        public static List<DayStockPrice> ToHistoricalStockPrices(this IEXResponse<IEnumerable<HistoricalPriceResponse>> prices)
        {
            if (!prices.IsDataPresent())
            {
                return new List<DayStockPrice>();
            }

            return prices.Data
                .Select(price => price.ToDayStockPrice())
                .ToList();
        }

        private static DayStockPrice ToDayStockPrice(this HistoricalPriceResponse price)
        {
            return new DayStockPrice
            {
                Date = DateTime.Parse(price.date),
                Open = price.open.Value,
                Close = price.close.Value,
                High = price.high.Value,
                Low = price.low.Value,
                Volume = price.volume.Value
            };
        }
    }
}
