using NSwag.Generation.AspNetCore;
using Stocks.NSwag.Processors.DocumentProcessors;
using Stocks.NSwag.Processors.OperationProcessors;
using System.Reflection;

namespace Stocks.NSwag.Bootstrap
{
    public static class OpenApiDocumentConfiguration
    {
        public static void EnableTagGroups(this AspNetCoreOpenApiDocumentGeneratorSettings settings, Assembly controllerAssembly)
        {
            settings.OperationProcessors.Add(new TagProcessor());
            settings.DocumentProcessors.Add(new TagGroupProcessor(controllerAssembly));
        }
    }
}
