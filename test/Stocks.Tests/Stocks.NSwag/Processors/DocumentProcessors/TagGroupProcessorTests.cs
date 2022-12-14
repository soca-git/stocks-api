using Moq;
using NSwag;
using NSwag.Generation.Processors.Contexts;
using Stocks.Controllers.Prices.Quote;
using Stocks.NSwag.Processors.DocumentProcessors;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Stocks.Tests.Stocks.NSwag.Processors.DocumentProcessors
{
    public class TagGroupProcessorTests
    {
        private readonly Assembly _controllerAssembly = typeof(StockQuoteController).Assembly;
        private readonly TagGroupProcessor _processor;
        private readonly Mock<DocumentProcessorContext> _context;

        public TagGroupProcessorTests()
        {
            _processor = new TagGroupProcessor(_controllerAssembly);

            var document = new Mock<OpenApiDocument>();
            document.Object.ExtensionData = new Dictionary<string, object>();
            _context = new Mock<DocumentProcessorContext>(document.Object, null, null, null, null, null);
        }

        [Fact]
        public void Successfully_Add_TagGroups()
        {
            _processor.Process(_context.Object);

            Assert.True(_context.Object.Document.ExtensionData.ContainsKey("x-tagGroups"));
            Assert.NotNull(_context.Object.Document.ExtensionData["x-tagGroups"]);
        }
    }
}
