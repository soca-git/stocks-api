using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Common.Contracts;
using Stocks.Api.Reference.Data;
using Stocks.Cache;
using Stocks.Controllers.Uri;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Controllers.Reference.Data
{
    /// <inheritdoc/>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/reference/data/stockinformation")]
    public class StockInformationController : ControllerBase, IStockInformation
    {
        private readonly IDataCache _cache;

        /// <summary>
        /// </summary>
        /// <param name="cache"></param>
        public StockInformationController(IDataCache cache)
        {
            _cache = cache;
        }

        /// <inheritdoc/>
        public async Task<List<StockInformation>> Get()
        {
            return _cache.StockInformation.Values.ToList();
        }
    }
}
