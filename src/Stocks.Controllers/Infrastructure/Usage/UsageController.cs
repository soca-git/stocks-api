using IEXSharp.Model;
using IEXSharp.Model.Account.Request;
using IEXSharp.Model.Account.Response;
using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Infrastructure.Usage;
using Stocks.Api.Infrastructure.Usage.Contracts;
using Stocks.Controllers._Internal.Mappers;
using Stocks.Controllers.Uri;
using Stocks.IEXCloud;
using System.Threading.Tasks;

namespace Stocks.Controllers.Infrastructure.Usage
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/infrastructure/usage")]
    public class UsageController : ControllerBase, IUsage
    {
        private readonly IIEXClient _client;

        /// <summary>
        /// </summary>
        /// <param name="client"></param>
        public UsageController(IIEXClient client)
        {
            _client = client;
        }
        
        /// <inheritdoc/>
        public async Task<CreditUsage> Get()
        {
            var accountData = await _client.Api.Account.MetadataAsync();

            return accountData.Data.ToCreditUsage();
        }
    }
}
