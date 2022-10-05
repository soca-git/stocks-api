using Stocks.Api.Common.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Api.Reference.Data
{
    public interface IStockInformation
    {
        /// <summary>
        /// Returns basic information for all stocks on the platform.
        /// </summary>
        /// <remarks>
        /// Add more description here!
        /// </remarks>
        Task<List<StockInformation>> Get();
    }
}
