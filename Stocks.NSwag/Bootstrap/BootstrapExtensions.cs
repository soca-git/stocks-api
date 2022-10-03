using NSwag.Generation.AspNetCore;
using System;
using System.Reflection;

namespace Stocks.NSwag.Bootstrap
{
    public static class BootstrapExtensions
    {
        public static void EnableOpenApiDocumentConfiguration(this AspNetCoreOpenApiDocumentGeneratorSettings settings,
            Assembly controllerAssembly, Action<OpenApiDocumentConfiguration> config)
        {
            var configuration = new OpenApiDocumentConfiguration(settings, controllerAssembly);
            config(configuration);
        }
    }
}
