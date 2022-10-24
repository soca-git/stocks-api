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
using Stocks.Shared.Utils;
using System.Linq;

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

        /// <summary>
        /// TODO: Refactor this to a new injectable search component
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private List<string> Search(StockSearchQuery query)
        {
            var matches = new List<SymbolMatch>();

            foreach (var symbol in _cache.StockInformation.Keys)
            {
                var indexOfMatch = symbol.IndexOf(query.Fragment, new char[] { ' ' });
                if (indexOfMatch != -1)
                {
                    matches.Add(new SymbolMatch(symbol, indexOfMatch));
                }
            }

            return matches.OrderBy(match => match.IndexOfMatch).Select(match => match.Symbol).Take(query.Count).ToList();
        }

        private class SymbolMatch
        {
            public SymbolMatch(string symbol, int indexOfMatch)
            {
                Symbol = symbol;
                IndexOfMatch = indexOfMatch;
            }

            public string Symbol { get; private set; }
            public int IndexOfMatch { get; private set; }
        }
    }
}
