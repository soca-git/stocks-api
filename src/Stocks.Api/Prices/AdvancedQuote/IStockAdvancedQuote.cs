﻿using Stocks.Api.Prices.AdvancedQuote.Contracts;
using System.Threading.Tasks;

namespace Stocks.Api.Prices.AdvancedQuote
{
    /// <summary>
    /// </summary>
    public interface IStockAdvancedQuote
    {
        /// <summary>
        /// Returns an advanced stock quote based on the search query.
        /// </summary>
        /// <remarks>
        /// Add more description here!
        /// </remarks>
        Task<StockAdvancedQuote> Get(StockAdvancedQuoteQuery query);
    }
}
