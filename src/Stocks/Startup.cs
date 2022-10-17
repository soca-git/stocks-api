using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stocks.Bootstrap;
using Stocks.Controllers._Internal.IEXCloud.Bootstrap;
using Stocks.Controllers.Search.Stocks;
using Stocks.NSwag.Bootstrap;

namespace Stocks
{
    public class Startup
    {
        private readonly Assembly controllerAssembly = typeof(StockSearchController).Assembly;
        private const string OpenApiPath = "/openapi/v1/openapi.json";
        private const string OpenApiDocumentName = "openapi";
        private const string Title = "Stocks API";
        private const string DescriptionMarkdown = "Description.md";

        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddApplicationPart(controllerAssembly)
                .AddControllersAsServices();

            services.RegisterAdditionalServices(_environment);

            ConfigureOpenApiDocument(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            ConfigureNSwag(app); // Do this before UseRouting();

            app.BuildDataFiles(_environment.ContentRootPath);

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseStaticFiles();

            // app.UseAuthorization();

            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }

        private static void ConfigureOpenApiDocument(IServiceCollection services)
        {
            services.AddOpenApiDocument(config =>
            {
                config.DocumentName = OpenApiDocumentName;
                config.DefaultReferenceTypeNullHandling = NJsonSchema.Generation.ReferenceTypeNullHandling.NotNull;
                config.Title = Title;
                config.DefaultEnumHandling = NJsonSchema.Generation.EnumHandling.String;

                // Stocks.NSwag configuration:
                config.EnableOpenApiDocumentConfiguration(
                    typeof(StockSearchController).Assembly,
                    config => config.EnableTagGroups().AddDescription(DescriptionMarkdown)
                );
            }); // registers a OpenAPI v3.0 document with the name "v1" (default)
        }

        private static void ConfigureNSwag(IApplicationBuilder app)
        {
            // Serves the registered OpenAPI documents
            app.UseOpenApi(config =>
            {
                config.DocumentName = OpenApiDocumentName;
                config.Path = OpenApiPath;
            });

            // Serves the Redoc UI to view the OpenAPI documents
            app.UseReDoc(config =>
            {
                config.Path = "/redoc";
                config.DocumentPath = OpenApiPath;
                config.CustomStylesheetPath = "/css/redoc.css";
            });
        }
    }
}
