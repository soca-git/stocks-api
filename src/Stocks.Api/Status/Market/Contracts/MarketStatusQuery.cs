using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stocks.Api.Status.Market.Contracts
{
    /// <summary>
    /// </summary>
    public class MarketStatusQuery
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
