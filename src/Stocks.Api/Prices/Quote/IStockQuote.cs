using Stocks.Api.Prices.Quote.Contracts;
using System.Threading.Tasks;

namespace Stocks.Api.Prices.Quote
{
    /// <summary>
    /// </summary>
    public interface IStockQuote
    {
        /// <summary>
        /// Returns a stock quote of the specified market instrument.
        /// </summary>
        /// <remarks>
        /// Add more description here!
        /// </remarks>
        Task<StockQuote> Get(StockQuoteQuery query);
    }
}
