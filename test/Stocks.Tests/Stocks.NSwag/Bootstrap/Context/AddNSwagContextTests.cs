using Microsoft.Extensions.Configuration;
using Moq;
using Stocks.NSwag.Bootstrap.Context;
using System;
using System.Reflection;
using Xunit;

namespace Stocks.Tests.Stocks.NSwag.Bootstrap.Context
{
    public class AddNSwagContextTests
    {
        private readonly Mock<IConfiguration> _configuration = new Mock<IConfiguration>();
        private readonly Assembly _someAssembly = typeof(AddNSwagContextTests).Assembly;

        [Fact]
        public void Successfully_Create_Context()
        {
            new AddNSwagContext(setup => 
            {
                setup.Configuration = _configuration.Object;
                setup.ControllerAssembly = _someAssembly;
                setup.DocumentationAssembly = _someAssembly;
            });
        }

        [Fact]
        public void Create_Context_With_Missing_Setup()
        {
            Action<AddNSwagContext> setupAction = setup => 
            {
                setup.Configuration = _configuration.Object;
                setup.ControllerAssembly = _someAssembly;
            };

            Assert.Throws<Exception>(() => new AddNSwagContext(setupAction));
        }
    }
}
