namespace Stocks.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveChars(this string @string, char[] charsToRemove)
        {
            foreach (var @char in charsToRemove)
            {
                @string = @string.Replace(@char.ToString(), string.Empty);
            }

            return @string;
        }
    }
}
