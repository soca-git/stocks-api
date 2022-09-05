using System;

namespace Stocks.Api.IEXCloud.StockPrices.Contracts
{
    public class DayStockPrice
    {
        /// <summary>
        /// The date of the day's stock price information.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The stock price on market open.
        /// </summary>
        public Decimal Open { get; set; }

        /// <summary>
        /// The stock price on market close.
        /// </summary>
        public Decimal Close { get; set; }

        /// <summary>
        /// The highest price of the stock during the day.
        /// </summary>
        public Decimal High { get; set; }

        /// <summary>
        /// The lowest price of the stock during the day.
        /// </summary>
        public Decimal Low { get; set; }

        /// <summary>
        /// The volume of stock traded during the day.
        /// </summary>
        public Decimal Volume { get; set; }
    }
}
