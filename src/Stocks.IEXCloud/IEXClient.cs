using IEXSharp;
using System;

namespace Stocks.IEXCloud
{
    internal class IEXClient : IIEXClient
    {
        private readonly IEXCloudClient _client;

        public IEXClient()
        {
            string sk = Environment.GetEnvironmentVariable("IEX_SK");
            string pk = Environment.GetEnvironmentVariable("IEX_PK");

            _client = new IEXCloudClient(pk, sk, signRequest: false, useSandBox: false);
        }

        public IEXCloudClient Api => _client;
    }
}
