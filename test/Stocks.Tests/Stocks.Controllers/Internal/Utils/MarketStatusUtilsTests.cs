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
            var openTime = DateTimeUtils.MillisecondsSinceEpoch(DateTime.UtcNow.AddHours(-1));
            var closeTime = DateTimeUtils.MillisecondsSinceEpoch(DateTime.UtcNow.AddHours(+1));

            Assert.Equal(MarketStatus.Open, MarketStatusUtils.CalculateMarketStatus(openTime, closeTime));
        }

        [Fact]
        public void Calculate_Market_Status_When_Market_Is_Closed()
        {
            var openTime = DateTimeUtils.MillisecondsSinceEpoch(DateTime.UtcNow.AddHours(-13));
            var closeTime = DateTimeUtils.MillisecondsSinceEpoch(DateTime.UtcNow.AddHours(-1));

            Assert.Equal(MarketStatus.Closed, MarketStatusUtils.CalculateMarketStatus(openTime, closeTime));
        }
    }
}
