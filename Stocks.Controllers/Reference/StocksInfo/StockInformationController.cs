using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public class StockInformationController : ControllerBase, IStockInformation
    {
        private readonly IEXClient _client = new IEXClient();
        private readonly string _projectRootPath;

        public StockInformationController(IHostingEnvironment hostingEnvironment)
        {
            _projectRootPath = hostingEnvironment.ContentRootPath;
        }

        /// <inheritdoc/>
        public async Task<List<StockBasicInformation>> Get()
        {
            if (Cache.StockBasicInformation == null)
            {
                Cache.StockBasicInformation = GetDataFromFile() ?? await GetDataFromApi();
            }

            return Cache.StockBasicInformation.Values.ToList();
        }

        private Dictionary<string, StockBasicInformation> GetDataFromFile()
        {
            try
            {
                var jsonData = System.IO.File.ReadAllText($"{_projectRootPath}\\..\\Data\\stock-basic-info.json");
                return JsonConvert.DeserializeObject<Dictionary<string, StockBasicInformation>>(jsonData);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        private async Task<Dictionary<string, StockBasicInformation>> GetDataFromApi()
        {
            var stocks = await _client.Api.ReferenceData.SymbolsAsync();
            return stocks.Data.ToStockBasicInfosHash();
        }
    }
}
