using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Prices.AdvancedQuote;
using Stocks.Api.Prices.AdvancedQuote.Contracts;
using Stocks.Cache;
using Stocks.IEXCloud;
using Stocks.Controllers.Uri;
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
            var response = new StockAdvancedQuote();

            if (quote.Data?.symbol != null)
            {
                response.TickerSymbol = quote.Data.symbol;
                response.Name = quote.Data.companyName;
                response.Currency = _cache.StockInformation[quote.Data.symbol].Currency;
                response.Market = _cache.StockInformation[quote.Data.symbol].Market;
                response.CurrentPrice = quote.Data.latestPrice ?? 0;
                response.CurrentDelta = quote.Data.change ?? 0;
                response.OpenPrice = quote.Data.iexOpen;
                response.ClosePrice = quote.Data.iexClose;
                response.HighPrice = quote.Data.high;
                response.LowPrice = quote.Data.low;
                response.Volume = quote.Data.iexVolume;
                response.AverageVolume = quote.Data.avgTotalVolume;
                response.PricePerEarningsRatio = quote.Data.peRatio;
                response.MarketCap = quote.Data.marketCap;
                response.FiftyTwoWeekHigh = quote.Data.week52High;
                response.FiftyTwoWeekLow = quote.Data.week52Low;

                // TODO
                response.Yield = null;
                response.Beta = null;
                response.EarningsPerShare = null;
            }

            return response;
        }
    }
}
