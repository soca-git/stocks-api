using Stocks.Shared.Utils;
using Xunit;

namespace Stocks.Tests.Stocks.Shared.Utils
{
    public class StringSearchUtilsTests
    {
        [Theory]
        [InlineData("AABB", "BB", 2)]
        [InlineData("AAAA AABBAAA", "BBAA", 6)]
        public void Search_Successfully_Finds_Match_When_(string symbol, string fragment, int expectedIndex)
        {
            var result = symbol.IndexOf(fragment, new char[] { ' ' });
            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData("AAAB", "ABA")]
        [InlineData("AAAB", "")]
        public void Search_Returns_Minus_One_When_No_Match_Found(string symbol, string fragment)
        {
            var result = symbol.IndexOf(fragment, new char[] { ' ' });
            Assert.Equal(-1, result);
        }
    }
}
