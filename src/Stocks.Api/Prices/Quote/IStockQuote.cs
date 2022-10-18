using Stocks.Api.Prices.Quote.Contracts;
using System.Threading.Tasks;

namespace Stocks.Api.Prices.Quote
{
    /// <summary>
    /// </summary>
    public interface IStockQuote
    {
        /// <summary>
        /// Returns a stock quote based on the search query.
        /// </summary>
        /// <remarks>
        /// Add more description here!
        /// </remarks>
        Task<StockQuote> Get(StockQuoteQuery query);
    }
}
