using IEXSharp.Model;
using Stocks.Controllers._Internal.Extensions;
using Xunit;

namespace Stocks.Tests.Stocks.Controllers.Internal.Extensions
{
    public class IEXResponseExtensionsTests
    {
        private readonly IEXResponse<string>[] _mockResponse
            = new IEXResponse<string>[] { new IEXResponse<string> { Data = "hello world!" } };

        private readonly IEXResponse<string>[] _mockEmptyResponse
            = new IEXResponse<string>[] { new IEXResponse<string> { Data = null } };

        [Fact]
        public void Is_Data_Present_Returns_True_When_Response_Contains_Data()
        {
            Assert.True(_mockResponse[0].IsDataPresent());
            Assert.True(_mockResponse.IsDataPresent());
        }

        [Fact]
        public void Is_Data_Present_Returns_False_When_Response_Does_Not_Contain_Data()
        {
            Assert.False(_mockEmptyResponse[0].IsDataPresent());
            Assert.False(_mockEmptyResponse.IsDataPresent());
        }
    }
}
