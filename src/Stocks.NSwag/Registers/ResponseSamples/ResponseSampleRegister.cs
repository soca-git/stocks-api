using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Stocks.NSwag.Registers.ResponseSamples
{
    internal class ResponseSampleRegister : IResponseSampleRegister
    {
        private readonly Dictionary<MethodInfo, List<ResponseSample>> _samples = new Dictionary<MethodInfo, List<ResponseSample>>();

        public List<ResponseSample> GetResponseSamples(MethodInfo method)
        {
            return _samples.ContainsKey(method) ? _samples[method] : new List<ResponseSample>();
        }

        public void AddResponseSample<TContract>(MethodInfo method, TContract response, string name)
        {
            if (!_samples.ContainsKey(method))
            {
                _samples.Add(method, new List<ResponseSample>());
            }

            _samples[method].Add(new ResponseSample { Name = name, Body = JToken.FromObject(response) });
        }
    }
}
