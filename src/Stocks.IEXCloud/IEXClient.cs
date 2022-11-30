using IEXSharp;

namespace Stocks.IEXCloud
{
    internal class IEXClient : IIEXClient
    {
        private const string PublicToken = "pk_d7996497b8844a999541274497663935";
        private const string SecretToken = "sk_5b4f8a0d878245189977ce9a2d366c50";
        //private const string PublicToken = "pk_593820d13f6a47f8a429bcd0be14b0f9";
        //private const string SecretToken = "sk_0b01190d64bf4bb1945ec45aefe10173";

        private readonly IEXCloudClient _client;

        public IEXClient()
        {
            _client = new IEXCloudClient(PublicToken, SecretToken, signRequest: false, useSandBox: false);
        }

        public IEXCloudClient Api => _client;
    }
}
