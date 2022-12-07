using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System.Reflection;

namespace Stocks.NSwag.Bootstrap.Extensions
{
    public static class CompositeApi
    {
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
                config.EnableTagGroups(controllerAssembly);
                config.AddJsonConverter<StringEnumConverter>();
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
