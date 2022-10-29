using Stocks.Api.News.Historical_News.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Api.News.Historical_News
{
    /// <summary>
    /// </summary>
    public interface IHistoricalStockNews
    {
        /// <summary>
        /// Returns historical news of the specified market instrument.
        /// </summary>
        /// <remarks>
        /// Add more description here!
        /// </remarks>
        Task<List<StockNewsArticle>> Get(HistoricalStockNewsQuery query);
    }
}
