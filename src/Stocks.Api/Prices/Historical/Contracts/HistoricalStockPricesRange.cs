namespace Stocks.Api.Prices.Historical.Contracts
{
    /// <summary>
    /// Range of time for which prices will be returned.
    /// </summary>
    public enum HistoricalStockPricesRange
    {
#pragma warning disable CS1591
        FiveDay,
        OneMonth,
        ThreeMonths,
        OneYear
    }
}
