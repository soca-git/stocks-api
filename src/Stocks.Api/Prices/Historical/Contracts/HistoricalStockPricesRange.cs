using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Stocks.Api.Prices.Historical.Contracts
{
    /// <summary>
    /// Range of time for which prices will be returned.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HistoricalStockPricesRange
    {
#pragma warning disable CS1591
        FiveDay,
        OneMonth,
        ThreeMonths,
        OneYear
    }
}
