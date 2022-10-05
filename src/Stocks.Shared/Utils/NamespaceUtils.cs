namespace Stocks.Shared.Utils
{
    public static class NamespaceUtils
    {
        public static string[] GetNamespaceSections(this string aNamespace)
        {
            return aNamespace.Split('.');
        }
    }
}
