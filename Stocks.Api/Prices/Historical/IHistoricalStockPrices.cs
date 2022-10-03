using System.Collections.Generic;
using System.Threading.Tasks;
using Stocks.Api.Prices.Historical.Contracts;

namespace Stocks.Api.Prices.Historical
{
    public interface IHistoricalStockPrices
    {
        /// <summary>
        /// Returns historical prices of the specified market instrument.
        /// </summary>
        /// <remarks>
        /// Add more description here!
        /// </remarks>
        Task<List<DayStockPrice>> Get(HistoricalStockPricesQuery query);
    }
}
