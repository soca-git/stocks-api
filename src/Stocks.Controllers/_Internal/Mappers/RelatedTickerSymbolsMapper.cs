using System.Collections.Generic;
using System.Linq;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class RelatedTickerSymbolsMapper
    {
        public static List<string> ToRelatedTickerSymbols(this string csv)
        {
            return csv.Split(',').ToList();
        }
    }
}
