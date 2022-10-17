using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Reference.Data;
using Stocks.Cache;
using Stocks.Controllers.Uri;
using System.Collections.Generic;
using System.Linq;

namespace Stocks.Controllers.Reference.Data
{
    /// <inheritdoc/>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/reference/data/tickersymbols")]
    public class TickerSymbolsController : ControllerBase, ITickerSymbols
    {
        private readonly IDataCache _cache;

        /// <summary>
        /// </summary>
        /// <param name="cache"></param>
        public TickerSymbolsController(IDataCache cache)
        {
            _cache = cache;
        }

        /// <inheritdoc/>
        public List<string> Get()
        {
            return _cache.StockInformation.Keys.ToList();
        }
    }
}
