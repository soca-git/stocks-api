namespace Stocks.Api.Status.Market.Contracts
{
    /// <summary>
    /// </summary>
    public class MarketStatusPreview
    {
        /// <summary>
        /// Name of the market.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The market's current status.
        /// </summary>
        public MarketStatus Status { get; set; }
    }
}
