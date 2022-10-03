using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Common.Contracts;
using Stocks.Api.Reference.StocksInfo;
using Stocks.Controllers._Internal.Cache;
using Stocks.Controllers._Internal.IEXCloud;
using Stocks.Controllers._Internal.Mappers;
using Stocks.Controllers.Uri;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Controllers.Reference.StocksInfo
{
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/reference/symbols")]
    public class StocksController : ControllerBase, IStocks
    {
        private readonly IEXClient client = new IEXClient();

        /// <inheritdoc/>
        public async Task<List<StockBasicInfo>> Get()
        {
            if (Cache.StockBasicInfoCache == null)
            {
                var stocks = await client.Api.ReferenceData.SymbolsAsync();
                Cache.StockBasicInfoCache = stocks.Data.ToStockBasicInfosHash();
            }

            return Cache.StockBasicInfoCache.Values.ToList();
        }
    }
}
