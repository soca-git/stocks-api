using Stocks.Api.Common.Contracts;

namespace Stocks.Api.Search.Stocks.Contracts
{
    public class StockPreview : StockBasicInfo
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
    }
}
