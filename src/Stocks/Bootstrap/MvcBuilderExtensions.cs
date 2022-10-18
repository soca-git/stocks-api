using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Stocks.Bootstrap
{
    public static class MvcBuilderExtensions
    {

        public static IMvcBuilder SetJsonOptions(this IMvcBuilder builder)
        {
            builder.AddJsonOptions(options =>
            {
                // This means response property names will be serialized as PascalCase (instead of camelCase by default).
                // Aligns with generated OpenAPI TypeScript clients.
                // The original discrepancy was that the OpenAPI specification is generated with PascalCase property names from the API interface contracts,
                // while the API was returning camelCase property names in the serialized response.
                options.JsonSerializerOptions.PropertyNamingPolicy = null;

                // This means response enum values will be serialized to their string representation (instead of integer by default).
                // The same converter is added to NSwag to keep the OpenAPI specification consistent.
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            return builder;
        }
    }
}
