using System;
using IEXSharp.Model.CoreData.StockPrices.Request;
using Stocks.Api.IEXCloud.StockPrices.Contracts;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class HistoricalStockPricesRangeMapper
    {
        [Obsolete("Use EnumUtils.ToEnumOrDefault()")]
        public static ChartRange ToIEXChartRange(this HistoricalStockPricesRange source)
        {
            ChartRange result;
            bool checkResult = Enum.TryParse<ChartRange>(source.ToString(), true, out result);

            return checkResult ? result : ChartRange.FiveDay;
        }
    }
}
