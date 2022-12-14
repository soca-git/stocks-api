using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System;

namespace Stocks.NSwag.Reflection
{
    /// <summary>
    /// </summary>
    public interface IApiProvider
    {
        /// <summary>
        /// Select an endpoint by specifying the corresponding controller and it's method.
        /// </summary>
        /// <typeparam name="TApiController"></typeparam>
        /// <typeparam name="TContract"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        MethodInfo SelectEndpoint<TApiController, TContract>(Expression<Func<TApiController, Task<TContract>>> selector);
    }
}
