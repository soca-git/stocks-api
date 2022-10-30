using IEXSharp.Model;

namespace Stocks.Controllers._Internal.Extensions
{
    internal static class IEXResponseExtensions
    {
        public static bool IsDataPresent<T>(this IEXResponse<T>[] response)
        {
            return response.Length > 0 && response[0].Data != null;
        }

        public static bool IsDataPresent<T>(this IEXResponse<T> response)
        {
            return response.Data != null;
        }
    }
}
