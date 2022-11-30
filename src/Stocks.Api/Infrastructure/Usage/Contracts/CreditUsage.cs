namespace Stocks.Api.Infrastructure.Usage.Contracts
{
    /// <summary>
    /// </summary>
    public class CreditUsage
    {
        /// <summary>
        /// The status of availability of credits.
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// The amount of credits used this month.
        /// </summary>
        public int AmountUsed { get; set; }

        /// <summary>
        /// The amount of credits remaining this month.
        /// </summary>
        public int AmountRemaining { get; set; }
    }
}
