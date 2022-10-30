using Moq;
using Stocks.Api.Common.Contracts;
using Stocks.Cache;
using System.Collections.Generic;

namespace Stocks.Tests.Mocks.Extensions
{
    internal static class MockDataCacheExtensions
    {
        public static Mock<IDataCache> WithMockData(this Mock<IDataCache> cache)
        {
            var mockData = new Dictionary<string, StockInformation>
            {
                { "QCOM", new StockInformation{ TickerSymbol = "QCOM", Name = "Qualcomm Inc.", Market = "XNAS", Currency = CurrencyCode.USD } },
                { "AAPL", new StockInformation{ TickerSymbol = "AAPL", Name = "Apple Inc", Market = "XNAS", Currency = CurrencyCode.USD } },
            };
            cache.Setup(cache => cache.StockInformation).Returns(mockData);

            return cache;
        }
    }
}
