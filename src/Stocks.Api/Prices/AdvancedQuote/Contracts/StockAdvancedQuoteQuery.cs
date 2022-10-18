using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stocks.Api.Prices.AdvancedQuote.Contracts
{
    /// <summary>
    /// </summary>
    public class StockAdvancedQuoteQuery
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
