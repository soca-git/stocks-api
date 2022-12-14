using Moq;
using NSwag.Generation.Processors.Contexts;
using NSwag;
using Stocks.NSwag.Processors.OperationProcessors;
using System.Collections.Generic;
using Xunit;
using Stocks.Controllers.Prices.Quote;

namespace Stocks.Tests.Stocks.NSwag.Processors.OperationProcessors
{
    public class TagProcessorTests
    {
        private readonly TagProcessor _processor;
        private readonly Mock<OperationProcessorContext> _context;

        public TagProcessorTests()
        {
            _processor = new TagProcessor();

            var description = new Mock<OpenApiOperationDescription>();
            var operation = description.Object.Operation = new OpenApiOperation();
            operation.Tags = new List<string>();
            _context = new Mock<OperationProcessorContext>(null, description.Object, typeof(StockQuoteController), null, null, null, null, null, null);
        }

        [Fact]
        public void Successfully_Add_Tags()
        {
            _processor.Process(_context.Object);

            Assert.NotEmpty(_context.Object.OperationDescription.Operation.Tags);
        }
    }
}
