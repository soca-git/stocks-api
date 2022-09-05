using System.Collections.Generic;
using System.Threading.Tasks;
using Stocks.Api.IEXCloud.StockPrices.Contracts;

namespace Stocks.Api.IEXCloud.StockPrices
{
    public interface IHistoricalStockPrices
    {
        Task<List<DayStockPrice>> Get(HistoricalStockPricesQuery query);
    }
}
