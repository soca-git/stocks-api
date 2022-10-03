using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using Stocks.NSwag.Utils;
using System.Collections.Generic;

namespace Stocks.NSwag.Processors.OperationProcessors
{
    internal class TagProcessor : IOperationProcessor
    {
        public bool Process(OperationProcessorContext context)
        {
            context.OperationDescription.Operation.Tags = new List<string> { context.ControllerType.Namespace.GetTag() };

            return true;
        }
    }
}
