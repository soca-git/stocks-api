using Newtonsoft.Json;
using NSwag.Generation.AspNetCore;
using Stocks.NSwag.Processors.DocumentProcessors;
using Stocks.NSwag.Processors.OperationProcessors;
using Stocks.NSwag.Providers.ResponseSamples;
using Stocks.NSwag.Reflection;
using Stocks.NSwag.Registers.ResponseSamples;
using Stocks.Shared.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Stocks.NSwag.Bootstrap.Extensions
{
    /// <summary>
    /// </summary>
    public static class Api
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="controllerAssembly"></param>
        /// <returns></returns>
        public static AspNetCoreOpenApiDocumentGeneratorSettings EnableTagGroups(this AspNetCoreOpenApiDocumentGeneratorSettings settings, Assembly controllerAssembly)
        {
            settings.OperationProcessors.Add(new TagProcessor());
            settings.DocumentProcessors.Add(new TagGroupProcessor(controllerAssembly));

            return settings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="relativePathToMarkdownFile"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static AspNetCoreOpenApiDocumentGeneratorSettings AddDescription(this AspNetCoreOpenApiDocumentGeneratorSettings settings, string relativePathToMarkdownFile)
        {
            if (!relativePathToMarkdownFile.EndsWith(".md"))
            {
                throw new Exception("Please specify a markdown file");
            }
            settings.Description = File.ReadAllText(relativePathToMarkdownFile);

            return settings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TConverter"></typeparam>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static AspNetCoreOpenApiDocumentGeneratorSettings AddJsonConverter<TConverter>(this AspNetCoreOpenApiDocumentGeneratorSettings settings)
            where TConverter : JsonConverter, new()
        {
            // ??= is called "compound assignment"
            settings.SerializerSettings ??= new JsonSerializerSettings();
            settings.SerializerSettings.Converters.Add(new TConverter());

            return settings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="documentationAssembly"></param>
        /// <returns></returns>
        public static AspNetCoreOpenApiDocumentGeneratorSettings AddResponseSamples(this AspNetCoreOpenApiDocumentGeneratorSettings settings, Assembly documentationAssembly)
        {
            var apiProvider = new ApiProvider();
            var register = new ResponseSampleRegister();

            var providers = documentationAssembly.GetExportedTypes().Where(t => typeof(IResponseSampleProvider).IsAssignableFrom(t));

            providers.ForEach(provider =>
            {
                var providerInstance = (IResponseSampleProvider) Activator.CreateInstance(provider);
                providerInstance.Register(apiProvider, register);
            });

            settings.OperationProcessors.Add(new ResponseSampleProcessor(register));

            return settings;
        }
    }
}
