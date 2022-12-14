using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using Stocks.NSwag.Registers.ResponseSamples;
using System.Collections.Generic;
using System.Linq;

namespace Stocks.NSwag.Processors.OperationProcessors
{
    internal class ResponseSampleProcessor : IOperationProcessor
    {
        private readonly ResponseSampleRegister _sampleRegister;

        public ResponseSampleProcessor(ResponseSampleRegister sampleRegister)
        {
            _sampleRegister = sampleRegister;
        }

        public bool Process(OperationProcessorContext context)
        {
            var method = context.MethodInfo;
            var responseSamples = _sampleRegister.GetResponseSamples(method);

            if (responseSamples.Count > 0)
            {
                AddResponseSamples(context, responseSamples);
            }

            return true;
        }

        private void AddResponseSamples(OperationProcessorContext context, List<ResponseSample> samples)
        {
            var specificationExamples = context.OperationDescription.Operation.Responses["200"].Content.First().Value.Examples;
            
            samples.ForEach(sample => specificationExamples.Add(sample.Name, new OpenApiExample { Value = sample.Body }) );
        }
    }
}
