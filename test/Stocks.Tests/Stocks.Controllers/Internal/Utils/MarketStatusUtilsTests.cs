using Stocks.Api.Status.Market.Contracts;
using Stocks.Controllers._Internal.Utils;
using Stocks.Shared.Utils;
using System;
using Xunit;

namespace Stocks.Tests.Stocks.Controllers.Internal.Utils
{
    public class MarketStatusUtilsTests
    {
        [Fact]
        public void Calculate_Market_Status_When_Market_Is_Open()
        {
            Assert.Equal(MarketStatus.Open, MarketStatusUtils.CalculateMarketStatus("15 minute delayed price"));
        }

        [Fact]
        public void Calculate_Market_Status_When_Market_Is_Closed()
        {
            Assert.Equal(MarketStatus.Closed, MarketStatusUtils.CalculateMarketStatus("Close"));
        }
    }
}
