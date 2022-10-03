using IEXSharp.Model.CoreData.ReferenceData.Response;
using Stocks.Api.Common.Contracts;
using Stocks.Shared.Extensions;
using Stocks.Shared.Utils;
using System.Collections.Generic;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class StockBasicInfoMapper
    {

        public static Dictionary<string, StockBasicInfo> ToStockBasicInfosHash(this IEnumerable<SymbolResponse> symbolResponses)
        {
            var hash = new Dictionary<string,StockBasicInfo>();
            symbolResponses.ForEach(response => {
                hash.TryAdd(response.symbol, response.ToStockBasicInfo());
            });

            return hash;
        }

        public static StockBasicInfo ToStockBasicInfo(this SymbolResponse symbolResponse)
        {
            return new StockBasicInfo {
                TickerSymbol = symbolResponse.symbol,
                Name = symbolResponse.name,
                Currency = EnumUtils.ToEnumOrDefault<CurrencyCode>(symbolResponse.currency, CurrencyCode.XXX)
            };
        }
    }
}
