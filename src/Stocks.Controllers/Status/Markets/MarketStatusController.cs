using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Status.Market;
using Stocks.Api.Status.Market.Contracts;
using Stocks.Cache;
using Stocks.IEXCloud;
using Stocks.Controllers.Uri;
using System.Threading.Tasks;
using Stocks.Controllers._Internal.Mappers;

namespace Stocks.Controllers.Status.Markets
{
    /// <inheritdoc/>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/status/markets")]
    public class MarketStatusController : ControllerBase, IMarketStatus
    {
        private readonly IIEXClient _client;
        private readonly IDataCache _cache;

        /// <summary>
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="client"></param>
        public MarketStatusController(IDataCache cache, IIEXClient client)
        {
            _cache = cache;
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<MarketStatusPreview> Get([FromQuery] MarketStatusQuery query)
        {
            var quote = await _client.Api.StockPrices.QuoteAsync(query.TickerSymbol);

            return quote.ToMarketStatus(_cache);
        }
    }
}
