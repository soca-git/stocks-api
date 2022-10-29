using IEXSharp.Model.Shared.Request;
using Stocks.Api.News.Historical_News.Contracts;
using Stocks.Shared.Utils;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class HistoricalStockNewsRangeMapper
    {
        public static TimeSeriesRange ToTimeSeriesRange(this HistoricalStockNewsRange source)
        {
            return EnumUtils.ToEnum<TimeSeriesRange>(source.GetDescription());
        }
    }
}
