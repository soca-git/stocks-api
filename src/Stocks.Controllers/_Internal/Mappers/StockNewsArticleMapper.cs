using IEXSharp.Model.CoreData.News.Response;
using Stocks.Api.News.Historical_News.Contracts;
using Stocks.Shared.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class StockNewsArticleMapper
    {
        public static List<StockNewsArticle> ToStockNewsArticles(this IEnumerable<NewsResponse> source)
        {
            return source
                .Select(article => article.ToStockNewsArticle())
                .ToList();
        }

        private static StockNewsArticle ToStockNewsArticle(this NewsResponse source)
        {
            return new StockNewsArticle
            {
                HeadLine = source.headline,
                Source = source.source,
                TimeStamp = source.datetime.ToUtcDateTime(),
                Url = source.url,
                RelatedTickerSymbols = source.related.ToRelatedTickerSymbols()
            };
        }
    }
}
