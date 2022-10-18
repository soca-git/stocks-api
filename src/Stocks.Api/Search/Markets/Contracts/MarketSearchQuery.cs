using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stocks.Api.Search.Markets.Contracts
{
    /// <summary>
    /// </summary>
    public class MarketSearchQuery
    {
        /// <summary>
        /// A market's name.
        /// </summary>
        /// <remarks>
        /// Example; "NASDAQ".
        /// </remarks>
        [BindRequired]
        public string Name { get; set; }
    }
}
