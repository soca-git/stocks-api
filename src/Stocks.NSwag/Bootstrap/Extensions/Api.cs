using Newtonsoft.Json;
using NSwag.Generation.AspNetCore;
using Stocks.NSwag.Processors.DocumentProcessors;
using Stocks.NSwag.Processors.OperationProcessors;
using System;
using System.IO;
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
    }
}
