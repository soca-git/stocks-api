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
            var knownUtcDateTime = DateTime.Parse("2022-10-19").ToUniversalTime();
            var millisecondsSinceEpoch = DateTimeUtils.MillisecondsSinceEpoch(knownUtcDateTime);

            Assert.Equal(1666134000000, millisecondsSinceEpoch);
        }
    }
}
