using IEXSharp.Model.CoreData.ReferenceData.Response;
using Stocks.Api.Common.Contracts;
using Stocks.Shared.Extensions;
using Stocks.Shared.Utils;
using System.Collections.Generic;

namespace Stocks.IEXCloud.Mappers
{
    internal static class StockInformationMapper
    {

        public static Dictionary<string, StockInformation> ToStockInformationHash(this IEnumerable<SymbolResponse> symbolResponses)
        {
            var hash = new Dictionary<string, StockInformation>();
            symbolResponses.ForEach(response =>
            {
                hash.TryAdd(response.symbol, response.ToStockInformation());
            });

            return hash;
        }

        private static StockInformation ToStockInformation(this SymbolResponse symbolResponse)
        {
            return new StockInformation
            {
                TickerSymbol = symbolResponse.symbol,
                Name = symbolResponse.name,
                Currency = EnumUtils.ToEnum<CurrencyCode>(symbolResponse.currency),
                Market = symbolResponse.exchange
            };
        }
    }
}
