using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using System.Reflection;

namespace Stocks.NSwag.Reflection
{
    internal class ApiProvider : IApiProvider
    {
        public MethodInfo SelectEndpoint<TApiController, TContract>(Expression<Func<TApiController, Task<TContract>>> selector)
        {
            var methodExpression = (MethodCallExpression)selector.Body;
            var method = methodExpression.Method;

            return method;
        }
    }
}
