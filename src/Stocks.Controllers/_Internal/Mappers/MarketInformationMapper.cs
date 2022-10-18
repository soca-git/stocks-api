using IEXSharp.Model.CoreData.ReferenceData.Response;
using Stocks.Api.Common.Contracts;
using Stocks.Shared.Extensions;
using System.Collections.Generic;

namespace Stocks.Controllers._Internal.Mappers
{
    public static class MarketInformationMapper
    {
        public static Dictionary<string, MarketInformation> ToMarketInformationHash(this IEnumerable<ExchangeInternationalResponse> source)
        {
            var hash = new Dictionary<string, MarketInformation>();
            source.ForEach(response => {
                hash.TryAdd(response.exchange, response.ToMarketInformation());
            });

            return hash;
        }

        public static MarketInformation ToMarketInformation(this ExchangeInternationalResponse source)
        {
            return new MarketInformation
            {
                Name = source.exchange,
                FullName = source.description,
                Region = source.region
            };
        }
    }
}
