using Stocks.Api.Prices.Quote.Contracts;
using Stocks.Controllers.Prices.Quote;
using Stocks.NSwag.Providers.ResponseSamples;
using Stocks.NSwag.Reflection;
using Stocks.NSwag.Registers.ResponseSamples;

namespace Stocks.Documentation.Prices.Quote.ResponseSamples
{
    public class StockQuoteResponseSampleProvider : IResponseSampleProvider
    {
        public void Register(IApiProvider api, IResponseSampleRegister register)
        {
            var method = api.SelectEndpoint<StockQuoteController, StockQuote>(endpoint => endpoint.Get(null));

            var qcom = new StockQuote
            {
                CurrentPrice = 111.19m,
                CurrentDelta = 0.4m,
                TickerSymbol = "QCOM",
                Name = "Qualcomm, Inc.",
                Currency = CurrencyCode.USD,
                Market = "XNAS"
            };

            register.AddResponseSample(method, qcom, "QCOM");

            var bb = new StockQuote
            {
                CurrentPrice = 4.4m,
                CurrentDelta = -0.18m,
                TickerSymbol = "BB",
                Name = "BlackBerry Ltd",
                Currency = CurrencyCode.USD,
                Market = "XNYS"
            };

            register.AddResponseSample(method, bb, "BB");
        }
    }
}
