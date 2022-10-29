using System;
using System.Collections.Generic;

namespace Stocks.Api.News.Historical_News.Contracts
{
    /// <summary>
    /// </summary>
    public class StockNewsArticle
    {
        /// <summary>
        /// The headline of the article.
        /// </summary>
        public string HeadLine { get; set; }

        /// <summary>
        /// The news source which released the article.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The access url of the article.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The timestamp (UTC) of the article's publication.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// A list of ticker symbols which are considered to be related to the article.
        /// </summary>
        public List<string> RelatedTickerSymbols { get; set; }
    }
}
