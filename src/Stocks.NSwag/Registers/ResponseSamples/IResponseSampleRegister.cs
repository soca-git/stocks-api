using System.Reflection;

namespace Stocks.NSwag.Registers.ResponseSamples
{
    public interface IResponseSampleRegister
    {
        void AddResponseSample<TContract>(MethodInfo method, TContract response, string name);
    }
}
