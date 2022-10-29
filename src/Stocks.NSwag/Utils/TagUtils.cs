using Stocks.Shared.Utils;

namespace Stocks.NSwag.Utils
{
    internal static class TagUtils
    {
        public static string GetTag(this string aNamespace)
        {
            var namespaceSections = aNamespace.GetNamespaceSections();
            return namespaceSections[namespaceSections.Length-1].Replace('_', ' ');
        }

        public static string GetTagGroup(this string aNamespace)
        {
            var namespaceSections = aNamespace.GetNamespaceSections();
            return namespaceSections[namespaceSections.Length - 2];
        }
    }
}
