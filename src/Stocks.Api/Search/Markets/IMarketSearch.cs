using Stocks.Api.Search.Markets.Contracts;
using System.Threading.Tasks;

namespace Stocks.Api.Search.Markets
{
    /// <summary>
    /// </summary>
    public interface IMarketSearch
    {
        /// <summary>
        /// Returns market previews based on the search query.
        /// </summary>
        /// <remarks>
        /// Add more description here!
        /// </remarks>
        Task<MarketPreview> Get(MarketSearchQuery query);
    }
}
