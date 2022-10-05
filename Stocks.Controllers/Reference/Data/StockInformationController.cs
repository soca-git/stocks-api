using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stocks.Api.Common.Contracts;
using Stocks.Api.Reference.Data;
using Stocks.Cache;
using Stocks.Controllers._Internal.IEXCloud;
using Stocks.Controllers._Internal.Mappers;
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
        private readonly IEXClient _client = new IEXClient();
        private readonly string _projectRootPath;

        public StockInformationController(IHostingEnvironment hostingEnvironment)
        {
            _projectRootPath = hostingEnvironment.ContentRootPath;
        }

        /// <inheritdoc/>
        public async Task<List<StockInformation>> Get()
        {
            if (DataCache.StockBasicInformation == null)
            {
                DataCache.StockBasicInformation = GetDataFromFile() ?? await GetDataFromApi();
            }

            return DataCache.StockBasicInformation.Values.ToList();
        }

        private Dictionary<string, StockInformation> GetDataFromFile()
        {
            try
            {
                var jsonData = System.IO.File.ReadAllText($"{_projectRootPath}\\..\\Data\\stock-information.json");
                return JsonConvert.DeserializeObject<Dictionary<string, StockInformation>>(jsonData);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        private async Task<Dictionary<string, StockInformation>> GetDataFromApi()
        {
            var stocks = await _client.Api.ReferenceData.SymbolsAsync();
            return stocks.Data.ToStockBasicInformationHash();
        }
    }
}
