using Moq;
using Stocks.Api.Common.Contracts;
using Stocks.Cache;
using Stocks.Controllers.Reference.Data;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Stocks.Tests.Stocks.Controllers.Reference.Data
{
    public class TickerSymbolsControllerTests
    {
        private readonly Mock<IDataCache> _cache;
        private readonly Dictionary<string, StockInformation> _moqStockInformation = new Dictionary<string, StockInformation>
        {
            { "AAPL", new StockInformation() },
            { "QCOM", new StockInformation() }
        };

        private readonly TickerSymbolsController _controller;

        public TickerSymbolsControllerTests()
        {
            _cache = new Mock<IDataCache>();
            _cache.Setup(cache => cache.StockInformation).Returns(_moqStockInformation);

            _controller = new TickerSymbolsController(_cache.Object);
        }

        [Fact]
        public void Get_Ticker_Symbols_Returns_List_Of_Ticker_Symbol_Strings()
        {
            var response = _controller.Get();

            Assert.IsType<List<string>>(response);
            Assert.Equal(_moqStockInformation.Keys.ToList(), response);
        }
    }
}
