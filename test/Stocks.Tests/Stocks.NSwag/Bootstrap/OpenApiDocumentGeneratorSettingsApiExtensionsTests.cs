using Newtonsoft.Json.Converters;
using NSwag.Generation.AspNetCore;
using Stocks.Controllers.Search.Stocks;
using Stocks.NSwag.Bootstrap.Extensions;
using System.Reflection;
using Xunit;

namespace Stocks.Tests.Stocks.NSwag.Bootstrap
{
    public class OpenApiDocumentGeneratorSettingsApiExtensionsTests
    {
        private const string RelativePathToTestMarkdownFile = @"Stocks.NSwag\Bootstrap\test.md";

        private readonly Assembly _controllerAssembly = typeof(StockSearchController).Assembly;
        private readonly AspNetCoreOpenApiDocumentGeneratorSettings _configuration;

        public OpenApiDocumentGeneratorSettingsApiExtensionsTests()
        {
            _configuration = new AspNetCoreOpenApiDocumentGeneratorSettings();
        }

        [Fact]
        public void Successfully_Add_Json_Converter()
        {
            _configuration.AddJsonConverter<StringEnumConverter>();
            Assert.NotEmpty(_configuration.SerializerSettings.Converters);
        }

        [Fact]
        public void Successfully_Add_Markdown_Description()
        {
            _configuration.AddDescription(RelativePathToTestMarkdownFile);
            Assert.NotEmpty(_configuration.Description);
        }
    }
}
