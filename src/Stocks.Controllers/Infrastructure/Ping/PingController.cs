using Microsoft.AspNetCore.Mvc;
using Stocks.Api.Infrastructure.Ping;
using Stocks.Controllers.Uri;
using System.Threading.Tasks;

namespace Stocks.Controllers.Infrastructure.Ping
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Route(BaseUri.GatewayPrefix + "/ping")]
    public class PingController : ControllerBase, IPing
    {
        /// <inheritdoc/>
        public async Task<string> Get()
        {
            return await Task.FromResult("Hello from Stocks-API!");
        }
    }
}
