using System;

namespace Stocks.Api.IEXCloud.StockPrices.Contracts
{
    public class DayStockPrice
    {
        public DateTime Date { get; set; }

        public Decimal Open { get; set; }

        public Decimal Close { get; set; }

        public Decimal High { get; set; }

        public Decimal Low { get; set; }

        public Decimal Volume { get; set; }
    }
}
