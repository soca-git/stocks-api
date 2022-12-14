using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace Stocks.NSwag.Bootstrap.Context
{
    /// <summary>
    /// </summary>
    public class AddNSwagContext
    {
        /// <summary>
        /// </summary>
        /// <param name="setupContext"></param>
        public AddNSwagContext(Action<AddNSwagContext> setupContext)
        {
            setupContext(this);
            CheckContextPropertyValues();
        }

        private void CheckContextPropertyValues()
        {
            if (GetType().GetProperties().Any(property => property.GetValue(this) == null))
            {
                throw new Exception("Please set all AddNSwagContext properties");
            }
        }

        /// <summary>
        /// ASP.NET startup configuration class
        /// </summary>
        public IConfiguration Configuration { get; set; }
        
        /// <summary>
        /// The assembly designated for API controllers
        /// </summary>
        public Assembly ControllerAssembly { get; set; }

        /// <summary>
        /// The assembly designated for documentation providers
        /// </summary>
        public Assembly DocumentationAssembly { get; set; }
    }
}
