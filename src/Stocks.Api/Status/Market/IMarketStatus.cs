using Stocks.Api.Status.Market.Contracts;
using System.Threading.Tasks;

namespace Stocks.Api.Status.Market
{
    /// <summary>
    /// </summary>
    public interface IMarketStatus
    {
        /// <summary>
        /// Returns market status based on the search query.
        /// </summary>
        /// <remarks>
        /// Add more description here!
        /// </remarks>
        Task<MarketStatusPreview> Get(MarketStatusQuery query);
    }
}
