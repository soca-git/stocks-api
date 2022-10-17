using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Stocks.Errors.Contracts
{
    public class StocksValidationProblemDetails : ValidationProblemDetails
    {
        public new List<ValidationError> Errors { get; set; }
    }
}
