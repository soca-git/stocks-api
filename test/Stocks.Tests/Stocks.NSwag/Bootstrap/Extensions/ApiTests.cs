using Newtonsoft.Json.Converters;
using NSwag.Generation.AspNetCore;
using Stocks.Controllers.Search.Stocks;
using Stocks.NSwag.Bootstrap.Extensions;
using System.Reflection;
using Xunit;

namespace Stocks.Tests.Stocks.NSwag.Bootstrap.Extensions
{
    public class ApiTests
    {
        private const string RelativePathToTestMarkdownFile = @"Stocks.NSwag\Bootstrap\test.md";

        private readonly AspNetCoreOpenApiDocumentGeneratorSettings _configuration;
        private readonly Assembly _controllerAssembly = typeof(StockSearchController).Assembly;

        public ApiTests()
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

        [Fact]
        public void Successfully_Enable_Tag_Groups()
        {
            _configuration.EnableTagGroups(_controllerAssembly);
            Assert.NotEmpty(_configuration.OperationProcessors);
            Assert.NotEmpty(_configuration.DocumentProcessors);
        }

        [Fact]
        public void Successfully_Add_Response_Samples()
        {
            _configuration.AddResponseSamples(_controllerAssembly);
            Assert.NotEmpty(_configuration.OperationProcessors);
        }
    }
}
