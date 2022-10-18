using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Prices.Quote;
using Stocks.Api.Prices.Quote.Contracts;
using Stocks.Cache;
using Stocks.Controllers._Internal.IEXCloud;
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
        private readonly IEXClient client = new IEXClient();
        private IDataCache _cache;

        /// <summary>
        /// </summary>
        /// <param name="cache"></param>
        public StockQuoteController(IDataCache cache)
        {
            _cache = cache;
        }

        /// <inheritdoc/>
        public async Task<StockQuote> Get([FromQuery] StockQuoteQuery query)
        {
            var quote = await client.Api.StockPrices.QuoteAsync(query.TickerSymbol);
            var response = new StockQuote();

            if (quote.Data?.symbol != null)
            {
                response.TickerSymbol = quote.Data.symbol;
                response.Name = quote.Data.companyName;
                response.Currency = _cache.StockInformation[quote.Data.symbol].Currency;
                response.Market = _cache.StockInformation[quote.Data.symbol].Market;
                response.CurrentPrice = quote.Data.latestPrice.Value;
                response.CurrentDelta = quote.Data.change.Value;
            }

            return response;
        }
    }
}
