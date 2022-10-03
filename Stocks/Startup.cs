using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddApplicationPart(controllerAssembly)
                .AddControllersAsServices();

            ConfigureOpenApiDocument(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureNSwag(app); // Do this before UseRouting();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            // app.UseAuthorization();

            if (env.IsDevelopment())
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

                // Stocks.NSwag configuration:
                config.EnableOpenApiDocumentConfiguration(
                    typeof(StockSearchController).Assembly,
                    config => config.EnableTagGroups().AddDescription("Description.md")
                );
            }); // registers a OpenAPI v3.0 document with the name "v1" (default)
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
            });
        }
    }
}
