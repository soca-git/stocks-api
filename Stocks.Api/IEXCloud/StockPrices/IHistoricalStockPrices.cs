using System.Collections.Generic;
using System.Threading.Tasks;
using Stocks.Api.IEXCloud.StockPrices.Contracts;

namespace Stocks.Api.IEXCloud.StockPrices
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
