using IEXSharp.Model;
using IEXSharp.Model.CoreData.News.Response;
using Stocks.Api.News.Historical_News.Contracts;
using Stocks.Controllers._Internal.Extensions;
using Stocks.Shared.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class StockNewsArticleMapper
    {
        public static List<StockNewsArticle> ToStockNewsArticles(this IEXResponse<IEnumerable<NewsResponse>> articles)
        {
            if (!articles.IsDataPresent())
            {
                return new List<StockNewsArticle>();
            }

            return articles.Data
                .Select(article => article.ToStockNewsArticle())
                .ToList();
        }

        private static StockNewsArticle ToStockNewsArticle(this NewsResponse article)
        {
            return new StockNewsArticle
            {
                HeadLine = article.headline,
                Source = article.source,
                TimeStamp = article.datetime.ToUtcDateTime(),
                Url = article.url,
                RelatedTickerSymbols = article.related.ToRelatedTickerSymbols()
            };
        }
    }
}
