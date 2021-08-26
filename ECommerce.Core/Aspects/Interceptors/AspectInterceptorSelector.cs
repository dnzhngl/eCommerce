using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace EShop.Core.Aspects.Interceptors
{
    public class AspectInterceptorSelector  :IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBase>(true).ToList();

            var mt = type.GetMethod(method.Name);
            var mtAttributes = (mt ?? throw new InvalidOperationException()).GetCustomAttributes<MethodInterceptionBase>(true);
            classAttributes.AddRange(mtAttributes);
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}