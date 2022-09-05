using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stocks.Api.IEXCloud.StockPrices.Contracts
{
    public class HistoricalStockPricesQuery
    {
        /// <summary>
        /// A market instrument ticker symbol, like "QCOM".
        /// </summary>
        [BindRequired]
        public string tickerSymbol { get; set; }
    }
}
