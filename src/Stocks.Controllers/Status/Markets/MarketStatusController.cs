using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Status.Market;
using Stocks.Api.Status.Market.Contracts;
using Stocks.Cache;
using Stocks.Controllers._Internal.Utils;
using Stocks.IEXCloud;
using Stocks.Controllers.Uri;
using System.Threading.Tasks;

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
            var response = new MarketStatusPreview();

            if (quote.Data != null)
            {
                var market = _cache.StockInformation[query.TickerSymbol].Market;
                response.Name = _cache.MarketInformation[market].FullName;
                response.Status = MarketStatusUtils.CalculateMarketStatus(quote.Data.latestSource);
            }

            return response;
        }
    }
}
