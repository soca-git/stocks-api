using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stocks.Api.Common.Contracts
{
    /// <summary>
    /// </summary>
    public class SearchQuery
    {
        /// <summary>
        /// </summary>
        public SearchQuery()
        {
            Count = 10;
        }

        /// <summary>
        /// The fragment used for the search.
        /// </summary>
        [BindRequired]
        public string Fragment { get; set; }

        /// <summary>
        /// The maximum number of results returned.
        /// </summary>
        /// <remarks>
        /// Defaults to 10.
        /// </remarks>
        public int Count { get; set; }
    }
}
