using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Search.Stocks;
using Stocks.Api.Search.Stocks.Contracts;
using Stocks.Cache;
using Stocks.IEXCloud;
using Stocks.Controllers.Uri;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Controllers.Search.Stocks
{
    /// <inheritdoc/>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/search/stocks")]
    public class StockSearchController : ControllerBase, IStockSearch
    {
        private readonly IIEXClient _client;
        private readonly IDataCache _cache;

        /// <summary>
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="client"></param>
        public StockSearchController(IDataCache cache, IIEXClient client)
        {
            _cache = cache;
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<List<StockPreview>> Get([FromQuery] StockSearchQuery query)
        {
            var quote = await _client.Api.StockPrices.QuoteAsync(query.TickerSymbol);
            var response = new List<StockPreview>();

            if (quote.Data?.symbol != null)
            {
                response.Add(new StockPreview
                {
                    TickerSymbol = quote.Data.symbol,
                    Name = quote.Data.companyName,
                    Currency = _cache.StockInformation[quote.Data.symbol].Currency,
                    Market = _cache.StockInformation[quote.Data.symbol].Market,
                    CurrentPrice = quote.Data.latestPrice.Value,
                    CurrentDelta = quote.Data.change.Value
                });
            }

            return response;
        }
    }
}
