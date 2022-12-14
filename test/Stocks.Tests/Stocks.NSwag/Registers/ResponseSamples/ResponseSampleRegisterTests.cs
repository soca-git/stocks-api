using Stocks.NSwag.Registers.ResponseSamples;
using Xunit;

namespace Stocks.Tests.Stocks.NSwag.Registers.ResponseSamples
{
    public class ResponseSampleRegisterTests
    {
        private readonly ResponseSampleRegister _register;

        public ResponseSampleRegisterTests()
        {
            _register = new ResponseSampleRegister();
        }

        [Fact]
        public void Register_And_Retrieve_Response_Sample_Test()
        {
            var method = _register.GetType().GetMethod("AddResponseSample");
            var contract = new TestContract();

            _register.AddResponseSample(method, contract, "Test Response Sample");

            Assert.NotEmpty(_register.GetResponseSamples(method));
        }

        private class TestContract
        {
        }
    }
}
