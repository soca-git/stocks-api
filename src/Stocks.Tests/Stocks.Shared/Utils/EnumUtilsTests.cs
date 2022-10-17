using Stocks.Shared.Utils;
using Xunit;

namespace Stocks.Tests.Stocks.Shared.Utils
{
    public class NamespaceUtilsTests
    {
        [Fact]
        public void GetNamespaceSections_Returns_Array_Of_Namespace_Section_Strings()
        {
            var mockNamespace = "Hello.World";
            var namespaceSections = mockNamespace.GetNamespaceSections();

            Assert.IsType<string[]>(namespaceSections);
            Assert.NotEmpty(namespaceSections);
            Assert.Equal(new string[] { "Hello", "World"}, namespaceSections);
        }
    }
}
