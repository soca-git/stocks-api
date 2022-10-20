using Stocks.Shared.Utils;
using System;
using Xunit;

namespace Stocks.Tests.Stocks.Shared.Utils
{
    public class DateTimeUtilsTests
    {
        [Fact]
        public void Calculate_Milliseconds_Since_Epoch_From_Known_DateTime()
        {
            var knownUtcDateTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-10-19T00:00:00"), TimeZoneInfo.Utc);
            var millisecondsSinceEpoch = DateTimeUtils.MillisecondsSinceEpoch(knownUtcDateTime);

            Assert.Equal(1666137600000, millisecondsSinceEpoch);
        }
    }
}
