using System;

namespace Stocks.Shared.Utils
{
    public static class DateTimeUtils
    {
        public static decimal MillisecondsSinceEpoch(DateTime time)
        {
            var timeSpanSinceEpoch = time - new DateTime(1970, 1, 1);
            return (decimal)timeSpanSinceEpoch.TotalMilliseconds;
        }
    }
}
