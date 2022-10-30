using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Prices.AdvancedQuote;
using Stocks.Api.Prices.AdvancedQuote.Contracts;
using Stocks.Cache;
using Stocks.IEXCloud;
using Stocks.Controllers.Uri;
using Stocks.Controllers._Internal.Mappers;
using System.Threading.Tasks;

namespace Stocks.Controllers.Prices.Quote
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/prices/advancedquote")]
    public class StockAdvancedQuoteController : ControllerBase, IStockAdvancedQuote
    {
        private readonly IIEXClient _client;
        private readonly IDataCache _cache;

        /// <summary>
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="client"></param>
        public StockAdvancedQuoteController(IDataCache cache, IIEXClient client)
        {
            _cache = cache;
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<StockAdvancedQuote> Get([FromQuery] StockAdvancedQuoteQuery query)
        {
            var quote = await _client.Api.StockPrices.QuoteAsync(query.TickerSymbol);

            return quote.ToStockAdvancedQuote(_cache);
        }
    }
}
