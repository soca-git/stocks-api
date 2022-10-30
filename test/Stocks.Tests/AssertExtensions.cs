using System.Text.Json;
using Xunit;

namespace Stocks.Tests
{
    internal class AssertExtensions : Assert
    {
        public static void JsonEqual(object mockContract, object mapContract)
        {
            Equal(JsonSerializer.Serialize(mockContract), JsonSerializer.Serialize(mapContract));
        }
    }
}
