using Stocks.Api.Search.Stocks.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Api.Search.Stocks
{
    public interface IStockSearch
    {
        /// <summary>
        /// Returns stock previews based on the search query.
        /// </summary>
        /// <remarks>
        /// Add more description here!
        /// </remarks>
        Task<List<StockPreview>> Get(StockSearchQuery query);
    }
}
