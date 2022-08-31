using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model.CoreData.StockPrices.Request;
using Microsoft.AspNetCore.Mvc;
using Stocks.Api.IEXCloud.StockPrices;
using Stocks.Api.IEXCloud.StockPrices.Contracts;

namespace Stocks.Controllers.IEXCloud.StockPrices
{
    [ApiController]
    [Route("/iexcloud/historicalstockprices")]
    public class HistoricalStockPricesController : ControllerBase, IHistoricalStockPrices
    {
        private readonly IEXCloud.IEXClient client;

        public HistoricalStockPricesController()
        {
            client = new IEXCloud.IEXClient();
        }

        [HttpGet]

        public async Task<List<DayStockPrice>> Get(string tickerSymbol)
        {
            var historicalPrices = await client.Api.StockPrices.HistoricalPriceAsync(tickerSymbol, ChartRange.OneMonth);

            var responsePrices = new List<DayStockPrice>();

            foreach (var price in historicalPrices.Data)
            {
                responsePrices.Add(new DayStockPrice
                {
                    Date = DateTime.Parse(price.date),
                    Open = price.open.Value,
                    Close = price.close.Value,
                    High = price.high.Value,
                    Low = price.low.Value,
                    Volume = price.volume.Value
                });
            }

            return responsePrices;
        }
    }
}
