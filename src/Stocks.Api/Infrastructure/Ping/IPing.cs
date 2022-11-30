using System.Threading.Tasks;

namespace Stocks.Api.Infrastructure.Ping
{
    public interface IPing
    {
        /// <summary>
        /// Returns a friendly message if the server is accessible.
        /// </summary>
        Task<string> Get();
    }
}
