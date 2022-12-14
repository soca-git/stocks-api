using Stocks.NSwag.Reflection;
using Stocks.NSwag.Registers.ResponseSamples;

namespace Stocks.NSwag.Providers.ResponseSamples
{
    public interface IResponseSampleProvider
    {
        void Register(IApiProvider api, IResponseSampleRegister register);
    }
}
