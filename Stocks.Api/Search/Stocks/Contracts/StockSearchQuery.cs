namespace Stocks.Api.Search.Stocks.Contracts
{
    public class StockSearchQuery
    {
        /// <summary>
        /// Instrument's ticker symbol.
        /// </summary>
        /// <remarks>
        /// Example; "QCOM".
        /// </remarks>
        public string TickerSymbol { get; set; }
    }
}
