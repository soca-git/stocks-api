using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.CoreData.StockPrices.Request;
using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Prices.Historical;
using Stocks.Api.Prices.Historical.Contracts;
using Stocks.IEXCloud;
using Stocks.Controllers.Uri;
using Stocks.Shared.Utils;
using Stocks.Controllers._Internal.Mappers;

namespace Stocks.Controllers.Prices.Historical
{
    /// <inheritdoc/>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/prices/historical")]
    public class HistoricalStockPricesController : ControllerBase, IHistoricalStockPrices
    {
        private readonly IIEXClient _client;

        /// <summary>
        /// </summary>
        /// <param name="client"></param>
        public HistoricalStockPricesController(IIEXClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<List<DayStockPrice>> Get([FromQuery] HistoricalStockPricesQuery query)
        {
            var range = query.range.ToString().ToEnumOrDefault(ChartRange.FiveDay);
            var prices = await _client.Api.StockPrices.HistoricalPriceAsync(query.tickerSymbol, range);

            return prices.ToHistoricalStockPrices();
        }
    }
}
