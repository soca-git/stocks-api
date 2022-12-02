using Microsoft.Extensions.Configuration;

namespace Stocks.Bootstrap.Extensions
{
    internal static class ConfigurationExtensions
    {
        public static string GetCorsPolicyName(this IConfiguration configuration)
        {
            return configuration.GetSection("Cors")["Name"];
        }

        public static string[] GetCorsPolicyUrls(this IConfiguration configuration)
        {
            return configuration.GetSection("Cors:Urls").Get<string[]>();
        }
    }
}
