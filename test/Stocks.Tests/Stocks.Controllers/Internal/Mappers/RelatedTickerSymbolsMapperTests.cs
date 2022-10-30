using Stocks.Controllers._Internal.Mappers;
using System.Collections.Generic;
using Xunit;

namespace Stocks.Tests.Stocks.Controllers.Internal.Mappers
{
    public class RelatedTickerSymbolsMapperTests
    {
        [Fact]
        public void Related_Ticker_Symbols_Mapper_Works_When_Multiple_Symbols()
        {
            Assert.Equal(new List<string> { "QCOM", "AAPL" }, "QCOM,AAPL".ToRelatedTickerSymbols());
        }

        [Fact]
        public void Related_Ticker_Symbols_Mapper_Works_When_Single_Symbol()
        {
            Assert.Equal(new List<string> { "QCOM" }, "QCOM".ToRelatedTickerSymbols());
        }

        [Fact]
        public void Related_Ticker_Symbols_Mapper_Works_When_Empty_String()
        {
            Assert.Equal(new List<string> { "" }, "".ToRelatedTickerSymbols());
        }
    }
}
