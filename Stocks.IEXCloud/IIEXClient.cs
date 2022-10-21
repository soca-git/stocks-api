using IEXSharp;

namespace Stocks.IEXCloud
{
    public interface IIEXClient
    {
        IEXCloudClient Api { get; }
    }
}
