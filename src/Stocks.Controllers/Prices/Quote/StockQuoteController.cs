using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Prices.Quote;
using Stocks.Api.Prices.Quote.Contracts;
using Stocks.Cache;
using Stocks.IEXCloud;
using Stocks.Controllers.Uri;
using System.Threading.Tasks;

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
            var response = new StockQuote();

            if (quote.Data?.symbol != null)
            {
                response.TickerSymbol = quote.Data.symbol;
                response.Name = quote.Data.companyName;
                response.Currency = _cache.StockInformation[quote.Data.symbol].Currency;
                response.Market = _cache.StockInformation[quote.Data.symbol].Market;
                response.CurrentPrice = quote.Data.latestPrice ?? -1;
                response.CurrentDelta = quote.Data.change ?? -1;
            }

            return response;
        }
    }
}
