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
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/reference/symbols")]
    public class StockInformationController : ControllerBase, IStockInformation
    {
        /// <inheritdoc/>
        public async Task<List<StockInformation>> Get()
        {
            return DataCache.StockBasicInformation.Values.ToList();
        }
    }
}
