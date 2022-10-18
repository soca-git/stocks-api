using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Prices.AdvancedQuote;
using Stocks.Api.Prices.AdvancedQuote.Contracts;
using Stocks.Cache;
using Stocks.Controllers._Internal.IEXCloud;
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
        private readonly IEXClient client = new IEXClient();
        private IDataCache _cache;

        /// <summary>
        /// </summary>
        /// <param name="cache"></param>
        public StockAdvancedQuoteController(IDataCache cache)
        {
            _cache = cache;
        }

        /// <inheritdoc/>
        public async Task<StockAdvancedQuote> Get([FromQuery] StockAdvancedQuoteQuery query)
        {
            var quote = await client.Api.StockPrices.QuoteAsync(query.TickerSymbol);
            var response = new StockAdvancedQuote();

            if (quote.Data?.symbol != null)
            {
                response.TickerSymbol = quote.Data.symbol;
                response.Name = quote.Data.companyName;
                response.Currency = _cache.StockInformation[quote.Data.symbol].Currency;
                response.Market = _cache.StockInformation[quote.Data.symbol].Market;
                response.CurrentPrice = quote.Data.latestPrice ?? -1;
                response.CurrentDelta = quote.Data.change ?? -1;
                response.OpenPrice = quote.Data.iexOpen ?? -1;
                response.ClosePrice = quote.Data.iexClose ?? -1;
                response.HighPrice = quote.Data.high ?? -1;
                response.LowPrice = quote.Data.low ?? -1;
                response.Volume = quote.Data.iexVolume ?? -1;
                response.AverageVolume = quote.Data.avgTotalVolume ?? -1;
                response.PricePerEarningsRatio = quote.Data.peRatio ?? -1;
                response.MarketCap = quote.Data.marketCap ?? -1;
                response.FiftyTwoWeekHigh = quote.Data.week52High ?? -1;
                response.FiftyTwoWeekLow = quote.Data.week52Low ?? -1;

                // TODO
                response.Yield = -1;
                response.Beta = -1;
                response.EarningsPerShare = -1;
            }

            return response;
        }
    }
}
