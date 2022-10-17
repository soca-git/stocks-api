using Stocks.Errors.Contracts;
using System.Collections.Generic;

namespace Stocks.Errors.Mappers
{
    public static class ValidationErrorMapper
    {
        public static List<ValidationError> ToValidationErrors(this ICollection<string[]> source)
        {
            var errors = new List<ValidationError>();

            foreach (var propertyErrors in source)
            {
                for (int i = 0; i < propertyErrors.Length; i++)
                {
                    errors.Add(new ValidationError(StocksApiErrorCodes.BadRequest.InvalidProperty, propertyErrors[i]));
                }
            }

            return errors;
        }
    }
}
