using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Stocks.Errors.Contracts;
using Stocks.Errors.Mappers;

namespace Stocks.Errors
{
    public class StocksProblemDetailsFactory : ProblemDetailsFactory
    {
        public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string title = null, string type = null, string detail = null, string instance = null)
        {
            return new ProblemDetails() { Status = statusCode ?? 500, Title = title, Type = type, Detail = detail, Instance = instance };
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string title = null, string type = null, string detail = null, string instance = null)
        {
            statusCode = statusCode ?? 400;

            var defaultProblemDetails = new ValidationProblemDetails(modelStateDictionary) { Status = statusCode, Type = type, Detail = detail, Instance = instance };

            var problemDetails = new StocksValidationProblemDetails
            {
                Status = defaultProblemDetails.Status,
                Title = defaultProblemDetails.Title,
                Type = defaultProblemDetails.Type ?? "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Detail = defaultProblemDetails.Detail,
                Instance = defaultProblemDetails.Instance,
                Errors = defaultProblemDetails.Errors.Values.ToValidationErrors(),
            };
            problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;

            return problemDetails;
        }
    }
}
