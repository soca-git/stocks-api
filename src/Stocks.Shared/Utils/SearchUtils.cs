using Stocks.Shared.Extensions;

namespace Stocks.Shared.Utils
{
    public static class SearchUtils
    {
        /// <summary>
        /// Customized IndexOf method.
        /// </summary>
        /// <param name="string">String to be searched.</param>
        /// <param name="fragment"></param>
        /// <param name="charsToIgnore"></param>
        /// <returns></returns>
        public static int IndexOf(this string @string, string fragment, char[] charsToIgnore)
        {
            @string = @string.ToLower().RemoveChars(charsToIgnore);
            fragment = fragment.ToLower();

            if (fragment.Length > @string.Length || fragment.Length == 0)
            {
                return -1;
            }
            "hello".IndexOf(@string);

            // Note: the rest is the same idea as System.String.IndexOf() ...
            int i = 0;
            int j = 0;
            int matchIndex = -1;
            while (i < @string.Length)
            {
                if (@string[i] == fragment[j])
                {
                    if (j == fragment.Length - 1)
                    {
                        return matchIndex;
                    }

                    if (j == 0)
                    {
                        matchIndex = i;
                    }
                    j++;
                }
                else
                {
                    matchIndex = -1;
                    j = 0;
                }
                i++;
            }

            return -1;
        }
    }
}
