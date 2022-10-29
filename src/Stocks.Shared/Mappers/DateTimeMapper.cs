using System;

namespace Stocks.Shared.Mappers
{
    public static class DateTimeMapper
    {
        /// <summary>
        /// Convert milliseconds since epoch time (Unix time) to UTC time.
        /// Epoch time is the number of seconds that have elapsed since 00:00:00 UTC on the 01/01/1970.
        /// </summary>
        /// <param name="millisecondsSinceEpoch"></param>
        /// <returns></returns>
        public static DateTime ToUtcDateTime(this long millisecondsSinceEpoch)
        {
            return DateTimeOffset.FromUnixTimeSeconds(millisecondsSinceEpoch / 1000).DateTime;
        }
    }
}
