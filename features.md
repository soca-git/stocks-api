
# Stocks-API Features
A walkthrough of the various features of this project.

- [Stocks-API Features](#stocks-api-features)
  - [API Design through Interfaces \& Contracts](#api-design-through-interfaces--contracts)
  - [API Implementation](#api-implementation)
  - [IEXCloud Client](#iexcloud-client)
  - [API Documentation](#api-documentation)
    - [NSwag Middleware Configuration](#nswag-middleware-configuration)
      - [Composite APIs](#composite-apis)
      - [Granular APIs](#granular-apis)
      - [Processors](#processors)
    - [Response Sample Framework](#response-sample-framework)
      - [Registration](#registration)
      - [Providers](#providers)
      - [Processing](#processing)

## API Design through Interfaces & Contracts
> The ```Stocks.Api``` project aims to capture the design of each API. The idea here is that the controllers implement the interface, which can be designed in a separate session.
> This allows the implementation to be completed at a later stage and follows the dependency inversion principle.
> 
> A typical interface is shown below.
```csharp
public interface IHistoricalStockNews
{
    /// <summary>
    /// Returns historical news of the specified market instrument.
    /// </summary>
    Task<List<StockNewsArticle>> Get(HistoricalStockNewsQuery query);
}
```
> Looking at the signature of the proposed API Get method, there are two contracts specified, one for the request query and the other for the response. 
```csharp
// The request query class
public class HistoricalStockNewsQuery
{
    public HistoricalStockNewsQuery()
    {
        Range = HistoricalStockNewsRange.PastWeek;
        Count = 10;
    }

    /// <summary>
    /// A market instrument's ticker symbol.
    /// </summary>
    [BindRequired]
    public string TickerSymbol { get; set; }

    /// <summary>
    /// The period of time for historical news to be returned.
    /// The default is "PastWeek".
    /// </summary>
    public HistoricalStockNewsRange Range { get; set; }

    /// <summary>
    /// The maximum number of results returned.
    /// Defaults to 10.
    /// </summary>
    public int Count { get; set; }
}

// The response class
public class StockNewsArticle
{
    /// <summary>
    /// The headline of the article.
    /// </summary>
    public string HeadLine { get; set; }

    /// <summary>
    /// The news source which released the article.
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// The access url of the article.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// The timestamp (UTC) of the article's publication.
    /// </summary>
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// A list of ticker symbols which are considered to be related to the article.
    /// </summary>
    public List<string> RelatedTickerSymbols { get; set; }
}
```
> The query class outlines the various parameters which can be used to retrieve historical news for a given stock. Validation attributes can also be specified here, outlining whether a parameter is required, for example. Defaults can also be specified through a parameterless constructor. This is the kind of information which can arise from discussions with the API consumers or business analysts.
>
> Similarly, the response class outlines what data will be returned from the API. This data will be consumed by the client and used to build the UI. The data returned and its type can be discussed with the API consumers or business analysts and the design contracts finalized based on these discussions.
>
> Ultimately, when implementing these API designs, the contracts for both the request and response are outlined. This allows the developer to decide what underlying APIs to aggregate in order to retrieve response data using the request contract.
>
> Furthermore, the API is designed first and not the implementation. This follows the dependency inversion principle, meaning the API does not rely on the details of the implementation, rather its design is an abstraction decided upon with business analysts.

## API Implementation
> As mentioned above, the API's interface represents an abstraction of the desired functionality. Now, the implementation and it's details can be built within a controller that implements the interface. The controllers are found in ```Stocks.Controllers```.
```csharp
[ApiController]
[Route(BaseUri.GatewayPrefix + "/news/historical")]
public class HistoricalStockNewsController : ControllerBase, IHistoricalStockNews
{
    private readonly IIEXClient _client;

    /// <summary>
    /// </summary>
    /// <param name="client"></param>
    public HistoricalStockNewsController(IIEXClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<StockNewsArticle>> Get([FromQuery] HistoricalStockNewsQuery query)
    {
        var news = await _client.Api.News.HistoricalNewsAsync(query.TickerSymbol, (TimeSeriesRange?)query.Range.ToTimeSeriesRange(), query.Count);
        
        return news.ToStockNewsArticles();
    }
}
```
> The details of the implementation such as the API's route and how it retrieves the data are built here. The controller has a single dependency ```IIEXClient``` which allows it to aggregate (if necessary, here only a single underlying call is made) underlying API calls to the IEXCloud, which is a third-party service used to retrieve live market information.
>
> Furthermore, any additional logic or data mapping can be performed here before returning the response.
>
> Note that if the method of retrieving the market data was to change, say because using the IEXCloud service became too expensive, a new set of controllers could be built, implementing the same set of interfaces from ```Stocks.Api```. Other components of the project would not have to change, for example the API documentation, since they rely on the API interfaces and not the controllers and their details.

## IEXCloud Client
> The market data used by the application comes from ```IEXCloud```. This is achieved by installing the ```IEXSharp``` package. The code related to utilizing the ```IEXSharp``` package is contained in the ```Stocks.IEXCloud``` project.
>
> The idea behind this project is straightforward, setup a client interface, implement it and register the interface implementation pair as a service for dependency injection, to be injected into the controllers.
```csharp
public interface IIEXClient
{
    IEXCloudClient Api { get; }
}
```
```csharp
internal class IEXClient : IIEXClient
{
    private readonly IEXCloudClient _client;

    public IEXClient()
    {
        string sk = Environment.GetEnvironmentVariable("IEX_SK");
        string pk = Environment.GetEnvironmentVariable("IEX_PK");

        _client = new IEXCloudClient(pk, sk, signRequest: false, useSandBox: false);
    }

    public IEXCloudClient Api => _client;
}
```
> The interface is publicly accessible to allow the controllers to reference it for dependency injection. Conversely, the details of the implementation are kept internal; the consumers of this project don't need to know how the client is setup.
>
> In order to register the client as a service, a public extension method on ```IServiceCollection``` is available, to be used during the application bootstrapping phase.
```csharp
public static class BootstrapExtensions
{
    /// <summary>
    /// Register the IEXClient component.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterIEXClient(this IServiceCollection services)
    {
        services.AddSingleton<IIEXClient, IEXClient>();

        return services;
    }
}
```
> When creating a class library like ```Stocks.IEXCloud```, it is important to limit what APIs are made public to consumers. Otherwise, upon installing the library as a dependency, consumers will have access to APIs which they do not require, bloating the interface of the library. Furthermore, unintentional access to excess APIs may cause consumers to misuse the library, which could cause a general misunderstanding of how to consume the library and potentially cause breaking changes in future versions.

## API Documentation
> The following section outlines how the NSwag middleware is consumed and configured in order to provide detailed API documentation.

### NSwag Middleware Configuration
#### Composite APIs
> A separate class library project is used to install and configure NSwag, named ```Stocks.NSwag```. The idea behind this is that other API projects will also require NSwag for API documentation, so setting up a common library to configure it will save time.
>
> The library aims to provide public extension methods for configuration of NSwag during application bootstrapping. This comes in to form of ```CompositeApi.cs``` and ```Api.cs```.
> ```CompositeApi``` provides extension methods for ```IServiceCollection``` and ```IApplicationBuilder``` (NSwag is by default configured through these two ASP.NET startup interfaces). The idea here is to provide default plug & play configuration, grouping any customizations of API documentation within the library together under two straightforward APIs.
> 
> The composite APIs are found [here](./src/Stocks.NSwag/Bootstrap/Extensions/CompositeApi.cs).
>
> Note that the composite APIs rely on some options specified in [appsettings.json](./src/Stocks/appsettings.json). This is outlined in the API xml description.
>
> Furthermore, note that the ```AddNSwag``` extension method of ```IServiceCollection``` required a few dependencies, so they are grouped under a single class ```AddNSwagContext```. Instead of requesting the consumer to pass in their own instance of the class, the parameter of the API is instead an ```Action``` delegate with a single parameter ```AddNSwagContext```. This allows for creation of the class to be moved inside the API and means the consumer only has to allocate the properties of the class.

#### Granular APIs
> Alternatively, if only some of the customization found in ```Stocks.NSwag``` is desired, ```Api.cs``` allows for specific customizations to be added during bootstrapping. Note: the composite APIs use these APIs under the hood. Each API here is built depending on what area of the API documentation is configured.
>
> For example, ```EnableTagGroups``` specifically enables grouping of APIs by their namespace, organizing the API documentation into sections.
```csharp
/// <summary>
/// Enable grouping of APIs by their namespace.
/// The APIs will then be grouped into sections in the API documentation.
/// </summary>
/// <param name="settings"></param>
/// <param name="controllerAssembly"></param>
/// <returns></returns>
public static AspNetCoreOpenApiDocumentGeneratorSettings EnableTagGroups(this AspNetCoreOpenApiDocumentGeneratorSettings settings, Assembly controllerAssembly)
{
    settings.OperationProcessors.Add(new TagProcessor());
    settings.DocumentProcessors.Add(new TagGroupProcessor(controllerAssembly));

    return settings;
}
```
> The method above is an example of a fluent API; it is an extension method of the NSwag class ```AspNetCoreOpenApiDocumentGeneratorSettings``` which returns an instance of ```AspNetCoreOpenApiDocumentGeneratorSettings```, allowing multiple configurations to be chained together. This is a common pattern used in configuration APIs.
>
> The more granular APIs are found [here](./src/Stocks.NSwag/Bootstrap/Extensions/Api.cs).

#### Processors
> The OpenAPI specification document can be customized through processors. There are two types of processor used in this project so far. The first is ```IDocumentProcessor``` which deals with customization of the document after it has been generated. This is used to supply additional information about the document, such as tag groups. See [TagGroupProcessor.cs](./src/Stocks.NSwag/Processors/DocumentProcessors/TagGroupProcessor.cs).
> 
> The second type of processor is ```IOperationProcessor```. This processor is called during document generation, on each API operation (i.e. on each API endpoint passed to the NSwag middleware). A simple example of an operation processor is [TagProcessor.cs](./src/Stocks.NSwag/Processors/OperationProcessors/TagProcessor.cs). This processor specifies a tag on each API endpoint, taken from the respective controller's namespace.

### Response Sample Framework
> This section of the NSwag customization deals with allowing developers to specify response samples for the API endpoints. This task would go hand-in-hand with API implementation, in order to provider more information to the API consumers on how a typical response from the API will look. There are three distinct sections to this framework:
> 1. Response sample registration.
> 2. Adding response sample providers.
> 3. Response sample processing.

#### Registration
> The first part of the framework deals with registration of response samples. This is exposed through the public extension method ```AddResponseSamples``` on the NSwag class ```AspNetCoreOpenApiDocumentGeneratorSettings```, during the bootstrapping phase.
```csharp
/// <summary>
/// Allows registration of response samples through response sample providers located in the specified "documentationAssembly".
/// </summary>
/// <param name="settings"></param>
/// <param name="documentationAssembly"></param>
/// <returns></returns>
public static AspNetCoreOpenApiDocumentGeneratorSettings AddResponseSamples(this AspNetCoreOpenApiDocumentGeneratorSettings settings, Assembly documentationAssembly)
{
    var apiProvider = new ApiProvider();
    var register = new ResponseSampleRegister();

    var providers = documentationAssembly.GetExportedTypes().Where(t => typeof(IResponseSampleProvider).IsAssignableFrom(t));

    providers.ForEach(provider =>
    {
        var providerInstance = (IResponseSampleProvider) Activator.CreateInstance(provider);
        providerInstance.Register(apiProvider, register);
    });

    settings.OperationProcessors.Add(new ResponseSampleProcessor(register));

    return settings;
}
```
> Instances of two classes are first created in this method; ```ApiProvider``` and ```ResponseSampleRegister```.
> ```ApiProvider``` is a generic class which allows endpoints to be selected through reflection by specifying their controller, return type and controller method.
```csharp
internal class ApiProvider : IApiProvider
{
    public MethodInfo SelectEndpoint<TApiController, TContract>(Expression<Func<TApiController, Task<TContract>>> selector)
    {
        var methodExpression = (MethodCallExpression)selector.Body;
        var method = methodExpression.Method;

        return method;
    }
}
```
> A ```Func``` delegate is used to select the endpoint method, with the controller type as a parameter and the response type as a return type. This is wrapped in an ```Expression``` in order to operate on the method's information itself and return it's respective ```MethodInfo```, rather then actually executing the method itself.
>
> The second object created is ```ResponseSampleRegister```.
```csharp
internal class ResponseSampleRegister : IResponseSampleRegister
{
    private readonly Dictionary<MethodInfo, List<ResponseSample>> _samples = new Dictionary<MethodInfo, List<ResponseSample>>();

    public List<ResponseSample> GetResponseSamples(MethodInfo method)
    {
        return _samples.ContainsKey(method) ? _samples[method] : new List<ResponseSample>();
    }

    public void AddResponseSample<TContract>(MethodInfo method, TContract response, string name)
    {
        if (!_samples.ContainsKey(method))
        {
            _samples.Add(method, new List<ResponseSample>());
        }

        _samples[method].Add(new ResponseSample { Name = name, Body = JToken.FromObject(response) });
    }
}
```
> This class stores all response samples for use by the processor later on. It has a single field which is a dictionary used to store the samples, with the key being the ```MethodInfo``` of the respective API endpoint for which the sample(s) is provided ```List<ResponseSample>```.
>
> It has two public methods, one to retrieve samples from the register and the other to add them to the register.
>
> Returning to the ```Api.cs/AddResponseSamples``` method, response sample providers are located through reflection by filtering the public types of the documentation assembly, in this case ```Stocks.Documentation```.  This is achieved by checking if the type implements the ```IResponseSampleProvider``` interface.
>
> An instance of each provider is then created and the interface method ```Register``` is called on each.
>
> Finally, the ```ResponseSampleProcessor``` processor is added to the NSwagConfiguration, passing in the instance of  ```ResponseSampleRegister```, which now contains all the registered response samples. 

#### Providers
> As mentioned above, response sample providers can be created inside a documentation assembly. These can be used to register response samples for the application's API endpoints. The ```IApiProvider``` parameter is used to select the endpoint through reflection, while the  ```IResponseSampleRegister``` parameter is used to add the response sample(s). These interfaces follow the interface segregation principle, in that they only expose the exact methods required by the developer creating the provider.
>
> A response sample provider can be found [here](./src/Stocks.Documentation/Prices/Quote/ResponseSamples/StockQuoteResponseSampleProvider.cs).

#### Processing
> Finally, the response samples can be processed and added to the document. This is achieved in [ResponseSampleProcessor.cs](./src/Stocks.NSwag/Processors/OperationProcessors/ResponseSampleProcessor.cs). The method info of the current API operation (endpoint) can be found in the ```OperationProcessorContext``` parameter. This can be used to search the ```ResponseSampleRegister``` passed in during the construction of the processor. If any response samples are registered for the given endpoint, they are added to the document.

---
