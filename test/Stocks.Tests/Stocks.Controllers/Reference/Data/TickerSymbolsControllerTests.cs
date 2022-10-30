using Moq;
using Stocks.Cache;
using Stocks.Controllers.Reference.Data;
using Stocks.Tests.Mocks.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Stocks.Tests.Stocks.Controllers.Reference.Data
{
    public class TickerSymbolsControllerTests
    {
        private readonly Mock<IDataCache> _mockCache;
        private readonly TickerSymbolsController _controller;

        public TickerSymbolsControllerTests()
        {
            _mockCache = new Mock<IDataCache>().WithMockData();
            _controller = new TickerSymbolsController(_mockCache.Object);
        }

        [Fact]
        public void Get_Ticker_Symbols_Returns_List_Of_Ticker_Symbol_Strings()
        {
            var response = _controller.Get();

            Assert.IsType<List<string>>(response);
            Assert.Equal(_mockCache.Object.StockInformation.Keys.ToList(), response);
        }
    }
}
