using Microsoft.Extensions.Configuration;

namespace Stocks.NSwag.Bootstrap.Extensions
{
    internal static class ConfigurationExtensions
    {
        public static string GetOpenApiDocumentName(this IConfiguration configuration)
        {
            return configuration.GetOpenApiSection()["Document:DocumentName"];
        }

        public static string GetOpenApiTitle(this IConfiguration configuration)
        {
            return configuration.GetOpenApiSection()["Document:Title"];
        }

        public static string GetOpenApiPath(this IConfiguration configuration)
        {
            return configuration.GetOpenApiSection()["Document:Path"];
        }

        public static IConfigurationSection GetOpenApiSection(this IConfiguration configuration)
        {
            return configuration.GetSection("OpenApi");
        }
    }
}
