using IEXSharp.Model;
using IEXSharp.Model.Shared.Response;
using Moq;
using Stocks.Api.Prices.Quote.Contracts;
using Stocks.Cache;
using Stocks.Controllers._Internal.Mappers;
using Stocks.Tests.Mocks.Extensions;
using System.Collections.Generic;
using Xunit;
using Assert = Stocks.Tests.AssertExtensions;

namespace Stocks.Tests.Stocks.Controllers.Internal.Mappers
{
    public class StockQuoteMapperTests
    {
        private readonly Mock<IDataCache> _mockCache;

        private readonly IEXResponse<Quote>[] _mockQuotes;
        private readonly IEXResponse<Quote>[] _mockEmptyQuotes;
        private readonly List<StockQuote> _mockMappedQuotes;

        public StockQuoteMapperTests()
        {
            _mockCache = new Mock<IDataCache>().WithMockData();

            _mockQuotes = new IEXResponse<Quote>[]
            {
                new IEXResponse<Quote>
                {
                    Data = new Quote
                    {
                        symbol = "QCOM",
                        companyName = "Qualcomm, Inc.",
                        latestPrice = 111.19m,
                        change = -0.4m
                    }
                },
                new IEXResponse<Quote>
                {
                    Data = new Quote
                    {
                        symbol = "AAPL",
                        companyName = "Apple Inc",
                        latestPrice = 135.08m,
                        change = 0.2m
                    }
                },
            };

            _mockEmptyQuotes = new IEXResponse<Quote>[]
            {
                new IEXResponse<Quote>{ Data = null }
            };

            _mockMappedQuotes = new List<StockQuote>
            {
                new StockQuote
                {
                    TickerSymbol = "QCOM",
                    Name = "Qualcomm, Inc.",
                    Market = "XNAS",
                    Currency = CurrencyCode.USD,
                    CurrentPrice = 111.19m,
                    CurrentDelta = -0.4m
                },
                new StockQuote
                {
                    TickerSymbol = "AAPL",
                    Name = "Apple Inc",
                    Market = "XNAS",
                    Currency = CurrencyCode.USD,
                    CurrentPrice = 135.08m,
                    CurrentDelta = 0.2m
                },
            };
        }

        [Fact]
        public void Stock_Quote_Mapping_Works()
        {
            Assert.JsonEqual(_mockMappedQuotes[0], _mockQuotes[0].ToStockQuote(_mockCache.Object));
        }

        [Fact]
        public void Stock_Quotes_Mapping_Works()
        {
            Assert.JsonEqual(_mockMappedQuotes, _mockQuotes.ToStockQuotes(_mockCache.Object));
        }

        [Fact]
        public void Stock_Quote_Returns_Empty_When_Input_Is_Null()
        {
            Assert.JsonEqual(null, _mockEmptyQuotes[0].ToStockQuote(_mockCache.Object));
        }

        [Fact]
        public void Stock_Quotes_Returns_Empty_When_Input_Is_Null()
        {
            Assert.JsonEqual(new List<StockQuote>(), _mockEmptyQuotes.ToStockQuotes(_mockCache.Object));
        }
    }
}
