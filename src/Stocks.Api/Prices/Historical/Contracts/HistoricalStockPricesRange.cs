using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Stocks.Api.Prices.Historical.Contracts
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HistoricalStockPricesRange
    {
        FiveDay,
        OneMonth,
        ThreeMonths,
        OneYear
    }
}
