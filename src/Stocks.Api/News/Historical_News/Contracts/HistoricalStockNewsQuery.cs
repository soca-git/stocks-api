using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stocks.Api.News.Historical_News.Contracts
{
    /// <summary>
    /// </summary>
    public class HistoricalStockNewsQuery
    {
        /// <summary>
        /// </summary>
        public HistoricalStockNewsQuery()
        {
            Range = HistoricalStockNewsRange.PastWeek;
            Count = 10;
        }

        /// <summary>
        /// A market instrument's ticker symbol.
        /// </summary>
        /// <remarks>
        /// Example; "QCOM".
        /// </remarks>
        [BindRequired]
        public string TickerSymbol { get; set; }

        /// <summary>
        /// The period of time for historical news to be returned.
        /// The default is "PastWeek".
        /// </summary>
        public HistoricalStockNewsRange Range { get; set; }

        /// <summary>
        /// The maximum number of results returned.
        /// Defaults to 10.
        /// </summary>
        public int Count { get; set; }
    }
}
