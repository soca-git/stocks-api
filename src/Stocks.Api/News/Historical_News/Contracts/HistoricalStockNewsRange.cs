using System.ComponentModel;

namespace Stocks.Api.News.Historical_News.Contracts
{
    /// <summary>
    /// Range of time for which news will be returned.
    /// </summary>
    /// <remarks>
    /// The description is used to map to IEX range values.
    /// </remarks>
    public enum HistoricalStockNewsRange
    {
#pragma warning disable CS1591
        [Description("Today")]
        Today,
        [Description("LastWeek")]
        PastWeek,
        [Description("LastMonth")]
        PastMonth
    }
}
