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
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            return builder;
        }
    }
}
