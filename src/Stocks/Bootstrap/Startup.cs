using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;
using Stocks.IEXCloud.Bootstrap;
using Stocks.Controllers.Search.Stocks;
using Stocks.NSwag.Bootstrap;
using Stocks.Bootstrap.Extensions;

namespace Stocks.Bootstrap
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        const string CORS_POLICY_DEV = "CorsPolicyDev";
        private string[] ORIGIN_URLS_DEV = { "http://localhost:3000" };

        const string CORS_POLICY_PROD = "CorsPolicyProd";
        private string[] ORIGIN_URLS_PROD = { "https://stocks-react-app.herokuapp.com" };

        private readonly Assembly controllerAssembly = typeof(StockSearchController).Assembly;
        private const string OpenApiPath = "/openapi/v1/openapi.json";
        private const string OpenApiDocumentName = "openapi";
        private const string Title = "Stocks API";
        private const string DescriptionMarkdown = "Description.md";

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .SetJsonOptions()
                .BuildDataFiles(_environment.ContentRootPath);

            services.SetCorsPolicy(CORS_POLICY_DEV, ORIGIN_URLS_DEV);
            services.SetCorsPolicy(CORS_POLICY_PROD, ORIGIN_URLS_PROD);
            services.RegisterAdditionalServices(_environment);

            ConfigureOpenApiDocument(services);
        }

        private void ConfigureOpenApiDocument(IServiceCollection services)
        {
            services.AddOpenApiDocument(config =>
            {
                config.DocumentName = "openapi";
                config.Title = Title;
                config.DefaultReferenceTypeNullHandling = NJsonSchema.Generation.ReferenceTypeNullHandling.NotNull;

                // Stocks.NSwag configuration:
                config.EnableOpenApiDocumentConfiguration(
                    controllerAssembly,
                    (config) =>
                    {
                        config
                            .EnableTagGroups()
                            //.AddDescription(DescriptionMarkdown)
                            .AddJsonConverter<StringEnumConverter>();
                    }
                );
            }); // registers a OpenAPI v3.0 document with the name "v1" (default)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            ConfigureCors(app);

            ConfigureNSwag(app); // Do this before UseRouting();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseStaticFiles();

            // app.UseAuthorization();
        }

        private void ConfigureCors(IApplicationBuilder app)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(CORS_POLICY_DEV);
            }

            if (_environment.IsProduction())
            {
                app.UseCors(CORS_POLICY_PROD);
            }
        }

        private void ConfigureNSwag(IApplicationBuilder app)
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
