using NSwag.Generation.AspNetCore;
using Stocks.NSwag.Processors.DocumentProcessors;
using Stocks.NSwag.Processors.OperationProcessors;
using System;
using System.IO;
using System.Reflection;

namespace Stocks.NSwag.Bootstrap
{
    public class OpenApiDocumentConfiguration
    {
        private readonly AspNetCoreOpenApiDocumentGeneratorSettings _settings;
        private readonly Assembly _controllerAssembly;

        public OpenApiDocumentConfiguration(AspNetCoreOpenApiDocumentGeneratorSettings settings, Assembly controllerAssembly)
        {
            _settings = settings;
            _controllerAssembly = controllerAssembly;
        }

        public OpenApiDocumentConfiguration EnableTagGroups()
        {
            _settings.OperationProcessors.Add(new TagProcessor());
            _settings.DocumentProcessors.Add(new TagGroupProcessor(_controllerAssembly));

            return this;
        }

        public void AddDescription(string relativePathToMarkdownFile)
        {
            if (!relativePathToMarkdownFile.EndsWith(".md"))
            {
                throw new Exception("Please specify a markdown file");
            }
            _settings.Description = File.ReadAllText(relativePathToMarkdownFile);
        }
    }
}
