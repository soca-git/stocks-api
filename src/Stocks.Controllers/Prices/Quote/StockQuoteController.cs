using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Prices.Quote;
using Stocks.Api.Prices.Quote.Contracts;
using Stocks.Cache;
using Stocks.IEXCloud;
using Stocks.Controllers.Uri;
using System.Threading.Tasks;
using Stocks.Controllers._Internal.Mappers;

namespace Stocks.Controllers.Prices.Quote
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/prices/quote")]
    public class StockQuoteController : ControllerBase, IStockQuote
    {
        private readonly IIEXClient _client;
        private readonly IDataCache _cache;

        /// <summary>
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="client"></param>
        public StockQuoteController(IDataCache cache, IIEXClient client)
        {
            _cache = cache;
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<StockQuote> Get([FromQuery] StockQuoteQuery query)
        {
            var quote = await _client.Api.StockPrices.QuoteAsync(query.TickerSymbol);
            return quote.ToStockQuote(_cache);
        }
    }
}
