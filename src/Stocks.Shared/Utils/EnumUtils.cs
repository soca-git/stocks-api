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

        public static TEnum ToEnum<TEnum>(this string source)
            where TEnum : struct
        {
            TEnum result;
            bool checkResult = Enum.TryParse<TEnum>(source, true, out result);

            return checkResult ? result : throw new Exception($"{nameof(TEnum)} does not contain a value that matches {source}");
        }
    }
}
