using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using NSwag.Generation.AspNetCore;
using System;
using System.Reflection;

namespace Stocks.NSwag.Bootstrap.Extensions
{
    /// <summary>
    /// </summary>
    public static class Api
    {
        private static void EnableOpenApiDocumentConfiguration(this AspNetCoreOpenApiDocumentGeneratorSettings settings,
            Assembly controllerAssembly, Action<OpenApiDocumentConfiguration> config)
        {
            var configuration = new OpenApiDocumentConfiguration(settings, controllerAssembly);
            config(configuration);
        }

        /// <summary>
        /// appsettings.cs:
        ///     "OpenApi": {
        ///         "Document": {
        ///             "Title": "<title>",
        ///             "DocumentName": "<documentName>",
        ///             "Path": "<path>"
        ///         }
        ///     }
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddNSwag(this IServiceCollection services, IConfiguration configuration, Assembly controllerAssembly)
        {
            services.AddOpenApiDocument(config => 
            {
                config.DocumentName = configuration.GetOpenApiDocumentName();
                config.Title = configuration.GetOpenApiTitle();
                config.DefaultReferenceTypeNullHandling = NJsonSchema.Generation.ReferenceTypeNullHandling.NotNull;

                config.EnableOpenApiDocumentConfiguration(
                    controllerAssembly,
                    options => options
                        .EnableTagGroups()
                        .AddJsonConverter<StringEnumConverter>()
                        //.AddDescription()
                    );
            });

            return services;
        }

        /// <summary>
        /// appsettings.cs:
        ///     "OpenApi": {
        ///         "Document": {
        ///             "Title": "<title>",
        ///             "DocumentName": "<documentName>",
        ///             "Path": "<path>"
        ///         }
        ///     }
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseNSwag(this IApplicationBuilder app, IConfiguration configuration)
        {
            // Serves the registered OpenAPI documents
            app.UseOpenApi(config =>
            {
                config.DocumentName = configuration.GetOpenApiDocumentName();
                config.Path = configuration.GetOpenApiPath();
            });

            // Serves the Redoc UI to view the OpenAPI documents
            app.UseReDoc(config =>
            {
                config.Path = "/redoc";
                config.DocumentPath = configuration.GetOpenApiPath();
                config.CustomStylesheetPath = "/css/redoc.css";
            });

            return app;
        }
    }
}
