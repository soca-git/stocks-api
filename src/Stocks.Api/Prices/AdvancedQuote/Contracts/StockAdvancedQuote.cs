using Stocks.Api.Common.Contracts;

namespace Stocks.Api.Prices.AdvancedQuote.Contracts
{
    /// <summary>
    /// </summary>
    public class StockAdvancedQuote : StockInformation
    {
        /// <summary>
        /// Instrument's current price.
        /// </summary>
        /// <remarks>
        /// This will reflect the live price during market open and the close price during market close.
        /// </remarks>
        public decimal CurrentPrice { get; set; }

        /// <summary>
        /// Instrument's current delta.
        /// </summary>
        /// <remarks>
        /// This will reflect the live gain/loss of the instrument during market open and the close gain/loss during market close.
        /// </remarks>
        public decimal CurrentDelta { get; set; }

        /// <summary>
        /// Instrument's price on market open.
        /// </summary>
        public decimal OpenPrice { get; set; }

        /// <summary>
        /// Instrument's price on market close.
        /// </summary>
        public decimal ClosePrice { get; set; }

        /// <summary>
        /// Instrument's highest price.
        /// </summary>
        /// <remarks>
        /// This will reflect the live highest price of the instrument during market open and the close highest price during market close.
        /// </remarks>
        public decimal HighPrice { get; set; }

        /// <summary>
        /// Instrument's lowest price.
        /// </summary>
        /// <remarks>
        /// This will reflect the live highest price of the instrument during market open and the close highest price during market close.
        /// </remarks>
        public decimal LowPrice { get; set; }

        /// <summary>
        /// Instrument's traded volume.
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// Instrument's average traded volume.
        /// </summary>
        public decimal AverageVolume { get; set; }

        /// <summary>
        /// Instrument's price per earnings ratio.
        /// </summary>
        public decimal PricePerEarningsRatio { get; set; }

        /// <summary>
        /// Instrument's market cap.
        /// </summary>
        public decimal MarketCap { get; set; }

        /// <summary>
        /// Instrument's highest value in the past 52 weeks.
        /// </summary>
        public decimal FiftyTwoWeekHigh { get; set; }

        /// <summary>
        /// Instrument's lowest value in the past 52 weeks.
        /// </summary>
        public decimal FiftyTwoWeekLow { get; set; }

        /// <summary>
        /// Instrument's yield.
        /// </summary>
        public decimal Yield { get; set; }

        /// <summary>
        /// Instrument's beta.
        /// </summary>
        public decimal Beta { get; set; }

        /// <summary>
        /// Instrument's earnings per share.
        /// </summary>
        public decimal EarningsPerShare { get; set; }
    }
}
