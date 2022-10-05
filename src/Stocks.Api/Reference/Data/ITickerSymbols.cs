using System.Collections.Generic;

namespace Stocks.Api.Reference.Data
{
    /// <summary>
    /// </summary>
    public interface ITickerSymbols
    {
        /// <summary>
        /// Returns a list of all ticker symbols on the platform.
        /// </summary>
        /// <remarks>
        /// Add more description here!
        /// </remarks>
        List<string> Get();
    }
}
