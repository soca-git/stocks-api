namespace Stocks.Api.Common.Contracts
{
    /// <summary>
    /// </summary>
    public class StockInformation
    {
        /// <summary>
        /// Instrument's ticker symbol.
        /// </summary>
        /// <remarks>
        /// Example; "QCOM".
        /// </remarks>
        public string TickerSymbol { get; set; }

        /// <summary>
        /// Instrument's name.
        /// </summary>
        /// <remarks>
        /// Example; "Qualcomm, Inc.".
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Instrument's traded currency.
        /// </summary>
        public CurrencyCode Currency { get; set; }

        /// <summary>
        /// Market instrument is traded on.
        /// </summary>
        public string Market { get; set; }
    }
}
