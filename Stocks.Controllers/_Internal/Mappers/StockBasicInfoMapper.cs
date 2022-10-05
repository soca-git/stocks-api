using IEXSharp.Model.CoreData.ReferenceData.Response;
using Stocks.Api.Common.Contracts;
using Stocks.Shared.Extensions;
using Stocks.Shared.Utils;
using System.Collections.Generic;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class StockBasicInfoMapper
    {

        public static Dictionary<string, StockBasicInformation> ToStockBasicInformationHash(this IEnumerable<SymbolResponse> symbolResponses)
        {
            var hash = new Dictionary<string,StockBasicInformation>();
            symbolResponses.ForEach(response => {
                hash.TryAdd(response.symbol, response.ToStockBasicInformation());
            });

            return hash;
        }

        public static StockBasicInformation ToStockBasicInformation(this SymbolResponse symbolResponse)
        {
            return new StockBasicInformation {
                TickerSymbol = symbolResponse.symbol,
                Name = symbolResponse.name,
                Currency = EnumUtils.ToEnum<CurrencyCode>(symbolResponse.currency)
            };
        }
    }
}
