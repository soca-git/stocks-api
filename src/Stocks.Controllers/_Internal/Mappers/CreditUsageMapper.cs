using IEXSharp.Model.Account.Response;
using Stocks.Api.Infrastructure.Usage.Contracts;

namespace Stocks.Controllers._Internal.Mappers
{
    internal static class CreditUsageMapper
    {
        public static CreditUsage ToCreditUsage(this MetadataResponse source)
        {
            int creditUsage = source.messagesUsed;
            int creditsRemaining = source.messageLimit - source.messagesUsed;

            return new CreditUsage
            {
                Available = creditsRemaining != 0 ? true : false,
                AmountUsed = creditUsage,
                AmountRemaining = creditsRemaining
            };
        }
    }
}
