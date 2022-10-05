using System;

namespace Stocks.Api.Prices.Historical.Contracts
{
    /// <summary>
    /// </summary>
    public class DayStockPrice
    {
        /// <summary>
        /// The date of the day's stock price information.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The stock price on market open.
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// The stock price on market close.
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// The highest price of the stock during the day.
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// The lowest price of the stock during the day.
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// The volume of stock traded during the day.
        /// </summary>
        public decimal Volume { get; set; }
    }
}
