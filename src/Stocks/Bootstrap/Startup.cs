using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stocks.IEXCloud.Bootstrap;
using Stocks.Controllers.Search.Stocks;
using Stocks.Bootstrap.Extensions;
using Stocks.NSwag.Bootstrap.Extensions;

namespace Stocks.Bootstrap
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        private readonly Assembly _controllerAssembly = typeof(StockSearchController).Assembly;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .SetJsonOptions()
                .BuildDataFiles(_environment.ContentRootPath);

            services.SetCorsPolicy(_configuration.GetCorsPolicyName(), _configuration.GetCorsPolicyUrls());
            services.AddNSwag(_configuration, _controllerAssembly);
            services.RegisterAdditionalServices(_environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseCors(_configuration.GetCorsPolicyName());

            app.UseNSwag(_configuration); // Do this before UseRouting();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseStaticFiles();

            //app.UseAuthorization();
        }
    }
}
