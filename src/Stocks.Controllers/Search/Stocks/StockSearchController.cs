using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Search.Stocks;
using Stocks.Api.Search.Stocks.Contracts;
using Stocks.Cache;
using Stocks.IEXCloud;
using Stocks.Controllers.Uri;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.Shared.Response;
using IEXSharp.Model;
using Stocks.Controllers._Internal.Mappers;

namespace Stocks.Controllers.Search.Stocks
{
    /// <inheritdoc/>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/search/stocks")]
    public class StockSearchController : ControllerBase, IStockSearch
    {
        private readonly IIEXClient _client;
        private readonly IDataCache _cache;

        /// <summary>
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="client"></param>
        public StockSearchController(IDataCache cache, IIEXClient client)
        {
            _cache = cache;
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<List<StockPreview>> Get([FromQuery] StockSearchQuery query)
        {
            var matches = Search(query);

            var quoteTasks = new List<Task<IEXResponse<Quote>>>();
            matches.ForEach(match => { quoteTasks.Add(_client.Api.StockPrices.QuoteAsync(match)); });

            var quotes = await Task.WhenAll(quoteTasks.ToArray());

            return quotes.ToStockQuotes(_cache).ToStockPreviews();
        }

        private List<string> Search(StockSearchQuery query)
        {
            var matches = new List<string>();

            foreach (var symbol in _cache.StockInformation.Keys)
            {
                if (matches.Count == query.Count)
                {
                    break;
                }

                if (symbol.Contains(query.Fragment))
                {
                    matches.Add(symbol);
                }
            }

            return matches;
        }
    }
}
