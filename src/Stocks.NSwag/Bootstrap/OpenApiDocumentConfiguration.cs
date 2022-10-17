using Newtonsoft.Json;
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

            HandleNullSettings();
        }

        private void HandleNullSettings()
        {
            if (_settings.SerializerSettings == null)
            {
                _settings.SerializerSettings = new JsonSerializerSettings();
            }
        }

        public OpenApiDocumentConfiguration EnableTagGroups()
        {
            _settings.OperationProcessors.Add(new TagProcessor());
            _settings.DocumentProcessors.Add(new TagGroupProcessor(_controllerAssembly));

            return this;
        }

        public OpenApiDocumentConfiguration AddDescription(string relativePathToMarkdownFile)
        {
            if (!relativePathToMarkdownFile.EndsWith(".md"))
            {
                throw new Exception("Please specify a markdown file");
            }
            _settings.Description = File.ReadAllText(relativePathToMarkdownFile);

            return this;
        }

        public OpenApiDocumentConfiguration AddJsonConverter<TConverter>()
            where TConverter : JsonConverter, new() 
        {
            _settings.SerializerSettings.Converters.Add(new TConverter());

            return this;
        }
    }
}
