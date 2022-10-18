namespace Stocks.Api.Common.Contracts
{
    /// <summary>
    /// </summary>
    public class MarketInformation
    {
        /// <summary>
        /// Market's exchange name.
        /// </summary>
        /// <remarks>
        /// Example; "XNYS".
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Market's full name.
        /// </summary>
        /// <remarks>
        /// Example; "New York Stock Exchange".
        /// </remarks>
        public string FullName { get; set; }

        /// <summary>
        /// Market's region.
        /// </summary>
        /// <remarks>
        /// Example; "United States".
        /// </remarks>
        public string Region { get; set; }
    }
}
