using System;

namespace Stocks.Shared.Utils
{
    public static class EnumUtils
    {
        public static TEnum ToEnumOrDefault<TEnum>(this string source, TEnum defaultValue)
            where TEnum : struct
        {
            TEnum result;
            bool checkResult = Enum.TryParse<TEnum>(source, true, out result);

            return checkResult ? result : defaultValue;
        }
    }
}
