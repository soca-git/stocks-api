using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stocks.Api.Prices.Quote.Contracts
{
    /// <summary>
    /// </summary>
    public class StockQuoteQuery
    {
        /// <summary>
        /// Instrument's ticker symbol.
        /// </summary>
        /// <remarks>
        /// Example; "QCOM".
        /// </remarks>
        [BindRequired]
        public string TickerSymbol { get; set; }
    }
}
