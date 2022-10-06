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
        /// <inheritdoc/>
        public List<string> Get()
        {
            return DataCache.StockInformation.Keys.ToList();
        }
    }
}
