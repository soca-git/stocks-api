using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.CoreData.StockPrices.Request;
using Microsoft.AspNetCore.Mvc;
using Stocks.Api.IEXCloud.StockPrices;
using Stocks.Api.IEXCloud.StockPrices.Contracts;
using Stocks.Shared.Extensions;
using Stocks.Shared.Utils;

namespace Stocks.Controllers.IEXCloud.StockPrices
{
    [ApiController]
    [Route("/iexcloud/historicalstockprices")]
    public class HistoricalStockPricesController : ControllerBase, IHistoricalStockPrices
    {
        private readonly IEXClient client = new IEXClient();

        /// <inheritdoc/>
        public async Task<List<DayStockPrice>> Get([FromQuery] HistoricalStockPricesQuery query)
        {
            var range = EnumUtils.ToEnumOrDefault(query.range.ToString(), ChartRange.FiveDay);

            var historicalPrices = await client.Api.StockPrices.HistoricalPriceAsync(query.tickerSymbol, range);

            var response = new List<DayStockPrice>();

            historicalPrices.Data.ForEach(price =>
            {
                response.Add(new DayStockPrice
                {
                    Date = DateTime.Parse(price.date),
                    Open = price.open.Value,
                    Close = price.close.Value,
                    High = price.high.Value,
                    Low = price.low.Value,
                    Volume = price.volume.Value
                });
            });

            return response;
        }
    }
}
