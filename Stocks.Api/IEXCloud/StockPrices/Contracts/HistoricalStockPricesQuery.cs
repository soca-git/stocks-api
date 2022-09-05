using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stocks.Api.IEXCloud.StockPrices.Contracts
{
    public class HistoricalStockPricesQuery
    {
        [BindRequired]
        public string tickerSymbol { get; set; }
    }
}
