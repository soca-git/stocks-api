using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stocks.Api.IEXCloud.StockPrices.Contracts
{
    public class HistoricalStockPricesQuery
    {
        /// <summary>
        /// A market instrument ticker symbol.
        /// </summary>
        /// <remarks>
        /// Examples; "QCOM", "AAPL".
        /// </remarks>
        [BindRequired]
        public string tickerSymbol { get; set; }

        /// <summary>
        /// The period of time for historical prices to be returned.
        /// The default is "FiveDay".
        /// </summary>
        public HistoricalStockPricesRange range { get; set; }
    }
}
