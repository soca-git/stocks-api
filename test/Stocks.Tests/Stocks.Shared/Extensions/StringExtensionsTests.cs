using Stocks.Shared.Extensions;
using Xunit;

namespace Stocks.Tests.Stocks.Shared.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void RemoveChars_Works()
        {
            var result = "h -ello".RemoveChars(new char[] { ' ', '-' });
            Assert.Equal("hello", result);
        }
    }
}
