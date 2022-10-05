using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Search.Stocks;
using Stocks.Api.Search.Stocks.Contracts;
using Stocks.Cache;
using Stocks.Controllers._Internal.IEXCloud;
using Stocks.Controllers.Uri;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Controllers.Search.Stocks
{
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/search/stocks")]
    public class StockSearchController : ControllerBase, IStockSearch
    {
        private readonly IEXClient client = new IEXClient();

        /// <inheritdoc/>
        public async Task<List<StockPreview>> Get(StockSearchQuery query)
        {
            var quote = await client.Api.StockPrices.QuoteAsync(query.TickerSymbol);

            var response = new List<StockPreview>();

            response.Add(new StockPreview
            {
                TickerSymbol = quote.Data.symbol,
                Name = quote.Data.companyName,
                Currency = DataCache.StockBasicInformation[quote.Data.symbol].Currency,
                CurrentPrice = quote.Data.latestPrice.Value,
                CurrentDelta = quote.Data.change.Value
            });

            return response;
        }
    }
}
