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
            var latestUpdate = DateTimeUtils.MillisecondsSinceEpoch(DateTime.UtcNow);

            Assert.Equal(MarketStatus.Open, MarketStatusUtils.CalculateMarketStatus(latestUpdate));
        }

        [Fact]
        public void Calculate_Market_Status_When_Market_Is_Closed()
        {
            var latestUpdate = DateTimeUtils.MillisecondsSinceEpoch(DateTime.UtcNow.AddMinutes(-17));

            Assert.Equal(MarketStatus.Closed, MarketStatusUtils.CalculateMarketStatus(latestUpdate));
        }
    }
}
