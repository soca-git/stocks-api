using Stocks.Api.Infrastructure.Usage.Contracts;
using System.Threading.Tasks;

namespace Stocks.Api.Infrastructure.Usage
{
    /// <summary>
    /// </summary>
    public interface IUsage
    {
        /// <summary>
        /// Returns credit usage from IEXCloud.
        /// </summary>
        Task<CreditUsage> Get();
    }
}
