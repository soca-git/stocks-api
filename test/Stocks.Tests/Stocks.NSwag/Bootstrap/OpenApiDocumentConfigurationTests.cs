using Newtonsoft.Json.Converters;
using NSwag.Generation.AspNetCore;
using Stocks.Controllers.Search.Stocks;
using Stocks.NSwag.Bootstrap;
using System.Reflection;
using Xunit;

namespace Stocks.Tests.Stocks.NSwag.Bootstrap
{
    public class OpenApiDocumentConfigurationTests
    {
        private const string RelativePathToTestMarkdownFile = @"Stocks.NSwag\Bootstrap\test.md";

        private readonly Assembly _controllerAssembly = typeof(StockSearchController).Assembly;
        private readonly AspNetCoreOpenApiDocumentGeneratorSettings _generatorSettings = new AspNetCoreOpenApiDocumentGeneratorSettings();
        private readonly OpenApiDocumentConfiguration _configuration;

        public OpenApiDocumentConfigurationTests()
        {
            _configuration = new OpenApiDocumentConfiguration(_generatorSettings, _controllerAssembly);
        }

        [Fact]
        public void Successfully_Add_Json_Converter()
        {
            _configuration.AddJsonConverter<StringEnumConverter>();
            Assert.NotEmpty(_generatorSettings.SerializerSettings.Converters);
        }

        [Fact]
        public void Successfully_Add_Markdown_Description()
        {
            _configuration.AddDescription(RelativePathToTestMarkdownFile);
            Assert.NotEmpty(_generatorSettings.Description);
        }
    }
}
