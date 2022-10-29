using IEXSharp.Model.CoreData.CorporateActions.Request;
using Microsoft.AspNetCore.Mvc;
using Stocks.Api.News.Historical_News;
using Stocks.Api.News.Historical_News.Contracts;
using Stocks.Controllers._Internal.Mappers;
using Stocks.Controllers.Uri;
using Stocks.IEXCloud;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Controllers.News.Historical_News
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/news/historical")]
    public class HistoricalStockNewsController : ControllerBase, IHistoricalStockNews
    {
        private readonly IIEXClient _client;

        /// <summary>
        /// </summary>
        /// <param name="client"></param>
        public HistoricalStockNewsController(IIEXClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<List<StockNewsArticle>> Get([FromQuery] HistoricalStockNewsQuery query)
        {
            var news = await _client.Api.News.HistoricalNewsAsync(query.TickerSymbol, (TimeSeriesRange?)query.Range.ToTimeSeriesRange(), query.Count);
            return news?.Data.ToStockNewsArticles();
        }
    }
}
