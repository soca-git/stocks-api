using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Stocks.Api.IEXCloud.StockPrices.Contracts
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
