namespace Stocks.Errors.Contracts
{
    /// <summary>
    /// Error response validation error, containing a code and message.
    /// </summary>
    public class ValidationError
    {
        public ValidationError(string code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// The error code, for example "NotFound".
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The error message, for example "The entity requested was not found".
        /// </summary>
        public string Message { get; }
    }
}
