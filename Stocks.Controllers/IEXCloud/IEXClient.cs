using IEXSharp;

namespace Stocks.Controllers.IEXCloud
{
    public class IEXClient
    {
        private const string PublicToken = "pk_d7996497b8844a999541274497663935";
        private const string SecretToken = "sk_5b4f8a0d878245189977ce9a2d366c50";
        private readonly IEXCloudClient _client;

        public IEXClient()
        {
            _client = new IEXCloudClient(PublicToken, SecretToken, signRequest: false, useSandBox: false);
        }

        public IEXCloudClient Api => _client;
    }
}
