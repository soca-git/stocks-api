using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stocks.Api.Prices.Historical.Contracts
{
    /// <summary>
    /// </summary>
    public class HistoricalStockPricesQuery
    {
        /// <summary>
        /// A market instrument's ticker symbol.
        /// </summary>
        /// <remarks>
        /// Example; "QCOM".
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
