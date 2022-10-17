namespace Stocks.Errors.Contracts
{
    public static class StocksApiErrorCodes
    {
        /// <summary>
        /// 400 BadRequest Error Codes
        /// </summary>
        public static class BadRequest
        {
            /// <summary>
            /// Default request validation error.
            /// </summary>
            public static string InvalidProperty => nameof(InvalidProperty);
        }

        /// <summary>
        /// 422 UnprocessableEntity Error Codes
        /// </summary>
        public static class UnprocessableEntity
        {
            /// <summary>
            /// Default platform validation error.
            /// </summary>
            public static string PlatformValidationError => nameof(PlatformValidationError);

            /// <summary>
            /// The entity requested was not found.
            /// </summary>
            public static string NotFound => nameof(NotFound);
        }
    }
}
